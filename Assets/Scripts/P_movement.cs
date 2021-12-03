using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class P_movement : MonoBehaviour
{
    public float speed;
    public int hp;
    public bool isDead = false;
    public Animator animator;

    private SpriteRenderer pSprite;
    public Transform hitBox;
    private Rigidbody2D pBody;
    private float attackTime = .80f;
    private float attackCounter = .80f;
    private float waitToLoad = 5f;
    private bool isAttacking = false;
    private bool reload = false;
    private bool facingRight = true;
    private bool facingLeft = true;
    private bool isMoving = false;




    void Start()
    {
        hp = 100;
        animator = GetComponent<Animator>();
        pSprite = GetComponent<SpriteRenderer>();
        pBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            pMovement();
        }
        else
        {
            playerDeath();
        }
            
    }
   
    void pMovement()
    {
        Vector2 dir = Vector2.zero;
        dir.Normalize();
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetBool("IsRunning", dir.magnitude > 0);
            pSprite.flipX = true;
            animator.SetBool("FullRun", true);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetBool("IsRunning", dir.magnitude > 0);
            pSprite.flipX = false;
            animator.SetBool("FullRun", true);
            isMoving = true;
            
        }
        else if (dir.magnitude == 0)
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("FullRun", false);
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetBool("IsRunning", dir.magnitude > 0);
            animator.SetBool("FullRun", true);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetBool("IsRunning", dir.magnitude > 0);
            animator.SetBool("FullRun", true);
            isMoving = true;
        }
        else if (dir.magnitude == 0)
        {
            animator.SetBool("FullRun", false);
            animator.SetBool("IsRunning", false);
            isMoving = false;
        }

        if(isMoving)
        {
            GetComponent<AudioSource>().UnPause();
        }
        else
        {
            GetComponent<AudioSource>().Pause();
        }
        pBody.velocity = speed * dir;

        if (isAttacking)
        {
            isMoving = false;
            pBody.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                animator.SetBool("IsAttacking", false);
                isAttacking = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            animator.SetBool("IsAttacking", true);
            isAttacking = true;
        }
        
    }
    
    void flipHitbox()
    {
        if(facingRight)
        {
            hitBox.transform.Rotate(0f, 180f, 0f);
            facingRight = false;
        }

        if(facingLeft)
        {
            hitBox.transform.Rotate(0f, 180f, 0f);
            facingLeft = false;
        }
    }

    void playerDeath()
    {
        if (isDead)
        {
            isMoving = false;
            pBody.velocity = Vector2.zero;
            animator.SetBool("FullRun", false);
            animator.SetBool("IsRunning", false);
            animator.SetBool("isDead", true);
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                reload = true;
            }

        }
        if (reload)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
