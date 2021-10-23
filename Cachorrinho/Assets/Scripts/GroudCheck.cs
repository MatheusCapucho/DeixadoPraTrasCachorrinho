using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudCheck : MonoBehaviour
{           
    MovPlayer Player;
    private Animator anim;
    
    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<MovPlayer>();
        lastJump = 0;
        anim = transform.parent.GetComponent<Animator>();
    }

    private float lastJump = 0;
    private float nextJump = 0;

    private void FixedUpdate()
    {
        nextJump = Time.timeSinceLevelLoad;
        if (nextJump > lastJump)
        {
            lastJump = Time.timeSinceLevelLoad + 5f;
            Player.isJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collisor)
            {
                    if(collisor.gameObject.layer == 8)
                    {
                        Player.isJump = false;
            anim.SetBool("isJumping", false);
        }
            }
         void OnCollisionExit2D(Collision2D collisor)
            { 
            if(collisor.gameObject.layer == 8)
            {
                Player.isJump = true;
            } 

            }  
 
 }       