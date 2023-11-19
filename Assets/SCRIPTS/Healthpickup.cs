using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpickup : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthAmount = 20; // Amount of health restored on pickup

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming you have a PlayerHealth script on your player GameObject
            PlayerHealth1 playerHealth = other.GetComponent<PlayerHealth1>();

            if (playerHealth != null)
            {
                playerHealth.RestoreHealth(healthAmount);
                Destroy(gameObject); // Destroy the health pickup after it's collected
            }
        }
    }
}
