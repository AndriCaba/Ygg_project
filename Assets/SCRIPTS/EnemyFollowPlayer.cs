using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    /*  public float speed;
      public float lineOfSite;
      public float shootingRange;
      public float firerate = 1f;
      public float NextFiretime;
      public GameObject bullet, bulletParent;
      private Transform player;

      // Start is called before the first frame update
      void Start()
      {
          player = GameObject.FindGameObjectWithTag("Player").transform;
      }

      // Update is called once per frame
      void Update()
      {
          float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);
          if (DistanceFromPlayer < lineOfSite && DistanceFromPlayer > shootingRange)
          {
              transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

          }
          else if (DistanceFromPlayer <= shootingRange && NextFiretime < Time.time)
          {
              transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
              Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
              NextFiretime = Time.time + firerate;


          }
      }
      private void OnDrawGizmosSelect()
      {

          Gizmos.color = Color.green;
          Gizmos.DrawWireSphere(transform.position, lineOfSite);
          Gizmos.DrawWireSphere(transform.position, shootingRange);


      }*/

    public Transform[] waypoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float lineOfSight = 5f;
    public float shootingRange = 3f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform bulletParent;

    private Transform player;
    private int currentWaypointIndex = 0;
    private float nextFireTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            // Chase the player
            ChasePlayer();
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            // Chase the player
            ChasePlayer();

            // Shoot
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        else
        {
            // Patrol between waypoints
            Patrol();
        }
    }

    void Patrol()
    {
        // Move towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, patrolSpeed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void ChasePlayer()
    {
        // Move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletParent.transform.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
