using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator enAnim;
    private SpriteRenderer eSprite;
    private Transform target;
    public Transform homePos;
    private bool pDead = false;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;
    [SerializeField]
    private float minRange;

    // Start is called before the first frame update
    void Start()
    {
        enAnim = GetComponent<Animator>();
        eSprite = GetComponent<SpriteRenderer>();
        target = FindObjectOfType<P_movement>().transform;
        pDead = FindObjectOfType<P_movement>().isDead;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(target.position,transform.position)<=range && Vector3.Distance(target.position, transform.position)>=minRange)
        {
            var relativePoint = transform.InverseTransformPoint(target.position);
            if (relativePoint.x < 0.0)
                eSprite.flipX = true;
            else
                eSprite.flipX = false;
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= range)
        {
            enAnim.SetBool("isInRange", false);
            goGome();
        }

        if(pDead == true)
        {
            goGome();
        }
    }

    public void FollowPlayer()
    {
        enAnim.SetBool("isMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);    
    }

    public void goGome()
    {
        var rpHome = transform.InverseTransformPoint(homePos.position);
        if (rpHome.x < 0.0)
            eSprite.flipX = true;
        else
            eSprite.flipX = false;
        transform.position = Vector3.MoveTowards(transform.position, homePos.transform.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position,homePos.position)== 0)
        {
            enAnim.SetBool("isMoving", false);
        }

    }
}
