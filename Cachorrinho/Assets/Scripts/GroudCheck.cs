using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudCheck : MonoBehaviour
{           
    MovPlayer Player;
    
    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<MovPlayer>();
    }

    // Update is called once per frame
        void OnCollisionEnter2D(Collision2D collisor)
            {
                    if(collisor.gameObject.layer == 8)
                    {
                        Player.isJump = false;
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