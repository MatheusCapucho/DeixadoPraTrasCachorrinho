using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    private int currentHealth;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            healthBar.UpadateSlider(-1);
            currentHealth--;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
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
