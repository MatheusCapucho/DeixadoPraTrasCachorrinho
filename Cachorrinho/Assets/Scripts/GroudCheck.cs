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
        anim = transform.parent.GetComponent<Animator>();
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