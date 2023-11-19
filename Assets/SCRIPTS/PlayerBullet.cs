using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = transform.right * speed;

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Debug.Log(hitInfo.name);
        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
        BossHealth boss = hitInfo.GetComponent<BossHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }

        if (boss != null)
        {
            boss.TakeDamage(damage);

        }
        Destroy(gameObject);

    }

}
