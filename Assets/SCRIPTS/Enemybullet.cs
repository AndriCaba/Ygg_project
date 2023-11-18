using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{

    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    public int damage = 40;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D> ();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y) ;
        Destroy(this.gameObject,2);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Debug.Log(hitInfo.name);
        PlayerHealth1 enemy = hitInfo.GetComponent<PlayerHealth1>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }

        Destroy(gameObject);

    }


}
