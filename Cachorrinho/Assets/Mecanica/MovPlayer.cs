using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{          
        public float speed;
        public float jump;
        [SerializeField] private float dashTime;
        public bool isJump;
       
       
        public Vector2 movement;
        private float dashAtual;
        private bool canDash;
        public float duracaoDash;


            [SerializeField] private float dashSpeed;

            private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
           rig = GetComponent<Rigidbody2D>(); 
           canDash = true;
           dashAtual =  duracaoDash;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Dash();
    }


    void Move()
    {
        Vector3 movement= new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * speed;


        if(movement.x > 0)
        {
             transform.eulerAngles = new Vector2(0f, 0f);
        }

        if(movement.x < 0)
        {
             transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isJump)
        {
                    rig.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.L) && canDash) {

            
            if(dashTime<= 0 )
            {
                StopDash();
            } else{
                canDash = true;
                dashAtual -= Time.deltaTime;


                if(movement.x > 0){
                        rig.velocity = Vector2.right * dashSpeed;

                }
                if(movement.x < 0){

                        rig.velocity = Vector2.left * dashSpeed;
                }
              if(Input.GetKeyDown(KeyCode.I)){
               canDash = true;
               dashAtual = duracaoDash;      

            }     
        }
                    
        }
       
            
        

         
    }
private void StopDash(){
            rig.velocity = Vector2.zero;
            dashAtual = duracaoDash;
            
            canDash = false; }
}
