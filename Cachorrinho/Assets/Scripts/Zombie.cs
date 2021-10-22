using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    [SerializeField] [Range(2, 20)] private float speed = 10f;
    private Vector3 startPos;
    private Vector3 moveRange = new Vector3 (1f, 0f, 0f);
    [SerializeField] float movementOffset = 5f;

    private GameObject player;
    [SerializeField] private float detectionRange = 5f;

    private bool isMovingRight = true;
    private Vector3 target;

    private bool aux;

    private Rigidbody2D rb;

    void Start()
    {
        startPos = this.gameObject.transform.position;
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        aux = true;
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < detectionRange)
        {
            MoveZombie();
        }
    }

    private void MoveZombie()
    {
        if (transform.position.x < player.transform.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
   
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

}
