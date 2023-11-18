using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {

            Shoot();
        }
    }
    void Shoot() {


        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    
    }
}
