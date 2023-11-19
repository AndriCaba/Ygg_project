using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth1 : MonoBehaviour
{



    public int maxHealth = 100; // Maximum health of the object
    public int currentHealth; // Current health of the object
    public GameObject deathEffect;
    public HealthbarSlider healthbar;

    public void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum health when the object is created
        healthbar.SetMaxHealth(maxHealth);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(20);
        }



    }
    public void TakeDamage(int damage)
    {


        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {

            Die();

        }

    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);


    }

    public void RestoreHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        healthbar.SetHealth(currentHealth);
        Debug.Log("Health Restored! Current Health: " + currentHealth);
    }
}
