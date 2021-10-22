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

    void Start()
    {
        startPos = this.gameObject.transform.position;
        target = startPos + (moveRange * movementOffset);
        player = GameObject.FindWithTag("Player");
        aux = true;
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position, startPos) < detectionRange)
        {
            MoveZombie();
        }

    }

    private void MoveZombie()
    {
        if (transform.position.x < target.x && isMovingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            isMovingRight = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, -target, speed * Time.deltaTime);
            isMovingRight = false;
        }

        if (transform.position.x <= -target.x)
            isMovingRight = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isMovingRight = !isMovingRight;
        }
    }


}
