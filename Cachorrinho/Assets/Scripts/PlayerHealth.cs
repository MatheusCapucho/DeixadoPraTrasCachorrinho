using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private int currentHealth;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpadateSlider(1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            healthBar.UpadateSlider(1);
            currentHealth--;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        // anim.setTrigger("Die");
        //ScneneManager.LoadScene(SceneManager/activescene);
    }

}
