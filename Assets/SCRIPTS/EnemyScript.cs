using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public int currentHealth;
    public HealthbarSlider healthbar;



    public void Start()
    {
        // Set the initial health to the maximum health when the object is created
        healthbar.SetMaxHealth(health);
    }
    public void TakeDamage(int damage)
    {
       

        health -= damage;
        healthbar.SetHealth(health);
        if (health <= 0)
        {

            Die();

        }


    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);


    }
}
