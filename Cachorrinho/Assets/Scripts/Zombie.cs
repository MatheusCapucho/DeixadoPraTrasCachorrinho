using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    [SerializeField] [Range(2, 20)] private float speed = 10f;
    private Vector3 startPos;
    private Vector3 moveRange = new Vector3 (1f, 0f, 0f);

    private GameObject player;
    [SerializeField] private float detectionRange = 5f;

    private Vector3 target;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isFacingRight = true;

    void Start()
    {
        startPos = this.gameObject.transform.position;
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < detectionRange)
        {
            MoveZombie();
        } else
        {
            anim.SetTrigger("Idle");
        }
    }

    private void MoveZombie()
    {
        anim.SetTrigger("Move");
        if (transform.position.x < player.transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (isFacingRight == false)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                isFacingRight = true;
            }
          
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (isFacingRight == true)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                isFacingRight = false;
            }
          

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

}
