using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    private int currentHealth;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private HealthBar healthBar;

    private Animator anim;
    private Collider2D col;
    private Coroutine cr;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {       
           
            if (cr == null)
            {
                currentHealth-=2;
                cr = StartCoroutine(Invencibility());
                healthBar.UpadateSlider(-2);
            }
            
           
            if (currentHealth <= 0)
            {
                Die();
            }
        }     
    }

    IEnumerator Invencibility()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1f);
        col.enabled = true;
        cr = null;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Osso"))
        {
            healthBar.UpadateSlider(1);
            currentHealth++;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            Destroy(other.gameObject);
        }
       
    }
    private void Die()
    {
        // anim.setTrigger("Die");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart level
    }

}
