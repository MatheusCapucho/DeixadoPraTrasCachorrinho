using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{          
        public float speed;
        public float jump;
     
        public bool isJump;
        public Vector2 movement;


        private float dashAtual;
        private bool canDash;
        public float duracaoDash;
        [SerializeField] private float dashTime;
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
        if(Input.GetKeyDown(KeyCode.L)){
            Dash();
            
        }
       
        if(canDash == true) {
            dashTime -= Time.deltaTime;
           if( dashTime <= 0){
                canDash = false;
            dashTime = duracaoDash;
           }
        }
        
      
    }


    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * speed;

<<<<<<< HEAD
=======
        float inputAxis = Input.GetAxis("Horizontal");
>>>>>>> dac441342e7aae323f5d638d041eda2b3a38e2d4

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
                canDash = true;
                if(rig.velocity.x > 0){
                        rig.velocity = Vector2.right * dashSpeed;
                        Debug.Log("BRUNO  NÃO ENTRO AQUI");
                        

                }
                if(rig.velocity.x < 0){

                        rig.velocity = Vector2.left * dashSpeed;

                }
             dashTime -= Time.deltaTime;
             
              
        }
                    
        
       
            
        

}
