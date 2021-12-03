using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hurt_Player : MonoBehaviour
{
    public hpManager hpMan;
    public float waitToHurt = 1f;
    public bool isTouching = false;

    void Start()
    {

    }

    void Update()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0)
            {
                hpMan.hurtPlayer(25);
                waitToHurt = 1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<hpManager>().hurtPlayer(25);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            isTouching = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 1f;
        }
    }
}
