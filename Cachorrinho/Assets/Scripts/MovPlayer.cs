using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{          
    public float speed;
    public float jump;
     
    public bool isJump;
    public Vector3 movement;

    private bool canDash;
    public float duracaoDash;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    private Rigidbody2D rig;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>(); 
        canDash = true;
        dashTime = duracaoDash;
    }
    void Update()
    {
        if (movement.x == 0) { 
            //anim.SetTrigger("Idle");
        }
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        Move();
        if (Input.GetKeyDown(KeyCode.W) && !isJump)
            Jump();
        if(Input.GetKeyDown(KeyCode.L) && canDash){
            Dash();         
        }
       
        if(!canDash) {
            dashTime -= Time.deltaTime;
           if( dashTime <= 0){
                canDash = true;
                dashTime = duracaoDash;
           }
        }
        
      
    }
    void Move()
    {

        rig.velocity = new Vector2(movement.x * speed, rig.velocity.y);

        if(movement.x > 0)
        {
            if (!isJump)
            {
                //anim.SetTrigger("Move");
            }
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        if(movement.x < 0)
        {
            if (!isJump)
            {
                //anim.SetTrigger("Move");
            }
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
    void Jump()
    {   
        rig.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        //anim.SetTrigger("Jump");
    }

    void Dash()
    {
        canDash = false;
        if (movement.x > 0)
        {
            transform.position += new Vector3(dashSpeed, 0f, 0f);
        }
        else if (movement.x < 0)
        {
            transform.position += new Vector3(-dashSpeed, 0f, 0f);
        }        
    }   

}
