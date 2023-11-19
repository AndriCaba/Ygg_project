using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject bulletPrefab;
    public SpriteRenderer spriteRenderer;

    public float shootCooldown = 0.5f; // Cooldown time between shots
    private float lastShotTime; // Time when the last shot was fired

    void Update()
    {
        // Check if enough time has passed since the last shot
        if (Time.time >= lastShotTime + shootCooldown)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                lastShotTime = Time.time; // Record the time of the last shot
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        // Additional shooting logic can be added here

        // Example: Play a sound or add visual effects
        // AudioManager.PlaySound("ShootSound");
        // Instantiate(muzzleFlashPrefab, firepoint.position, firepoint.rotation);
    }

    public void UpdateOrientation(bool isFacingRight)
    {
        spriteRenderer.flipX = !isFacingRight;
    }


}
