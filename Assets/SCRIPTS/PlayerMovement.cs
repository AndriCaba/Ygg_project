using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float moveSpeed = 5f;
    //public float dashSpeed = 10f;
    //public float dashDuration = 0.2f;
    //private bool isDashing = false;
    //public Transform playerTransform; 

    //public SpriteRenderer spriteRenderer;
    //public bool m_FacingRight = true;

    //void Update()
    //{
    //    // Regular movement
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    Vector2 movement = new Vector2(horizontalInput, verticalInput);
    //    movement.Normalize();
    //    transform.Translate(movement * moveSpeed * Time.deltaTime);

    //    // Dash
    //    if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
    //    {
    //        StartCoroutine(Dash());
    //    }

    //    if (horizontalInput > 0 && !m_FacingRight)
    //    {
    //        Flip();
    //    }
    //    else if (horizontalInput < 0 && m_FacingRight)
    //    {
    //        Flip();
    //    }
    //}

    //IEnumerator Dash()
    //{
    //    isDashing = true;
    //    float startTime = Time.time;

    //    while (Time.time < startTime + dashDuration)
    //    {
    //        float horizontalInput = Input.GetAxis("Horizontal");
    //        float verticalInput = Input.GetAxis("Vertical");

    //        Vector2 dashDirection = new Vector2(horizontalInput, verticalInput);
    //        dashDirection.Normalize();
    //        transform.Translate(dashDirection * dashSpeed * Time.deltaTime);

    //        yield return null;
    //    }

    //    isDashing = false;
    //}

    //public void Flip()
    //{
    //    m_FacingRight = !m_FacingRight;
    //    playerTransform.Rotate(0f, 180f, 0f);


    //}


    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;
    public Transform playerTransform;

    public bool m_FacingRight = true;

    void Update()
    {
        // Regular movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        // Flip the movement direction when facing left
        if (!m_FacingRight)
        {
            movement.x *= -1f;
        }

        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Dash
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        if (horizontalInput > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && m_FacingRight)
        {
            Flip();
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 dashDirection = new Vector2(horizontalInput, verticalInput);
            dashDirection.Normalize();

            // Flip the dash direction when facing left
            if (!m_FacingRight)
            {
                dashDirection.x *= -1f;
            }

            transform.Translate(dashDirection * dashSpeed * Time.deltaTime);

            yield return null;
        }

        isDashing = false;
    }

    public void Flip()
    {
        m_FacingRight = !m_FacingRight;
        playerTransform.Rotate(0f, 180f, 0f);
    }
}
