using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float FollowSpeed = 2f;
    public float yOffset = 1F;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        // Make sure the target is not null before trying to access its position
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Target is not assigned. Please assign a target in the inspector.");
        }
    }
}
