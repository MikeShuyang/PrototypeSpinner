using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Global Setting Parameters
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private float moveSpeed;
    
    // Conditions
    [SerializeField] private bool isGrounded = false;

    // Player Movement
    private Vector3 velocity;
    private float horizontal = 0;
    private float vertical = 0;
    [SerializeField] private bool isHoldingJump = false; // Whether the player is holding jump
    [SerializeField] private float maxHoldJumpTime; // The max amount of time the player can hold the jump
    [SerializeField] private float jumpHoldTimer; // A hold-jump timer

    private void OnCollisionEnter(Collision collision)
    {
        // Only when the player collides with the Platform object, land the player
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        // If the player is not colliding with the platform, it's not grounded
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Basic movement
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        // Jump handling
        if (isGrounded)
        {
            jumpHoldTimer = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpForce;
                isHoldingJump = true;
            }
        }

        if (transform.position.y < 0)
        {
            isGrounded = false;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }

    private void FixedUpdate()
    {
        // Get the current position
        Vector3 position = transform.position;

        
        // Do something about the position
        // Basic movement
        if (horizontal != 0 || vertical != 0)
        {
            position.x += moveSpeed * horizontal * Time.fixedDeltaTime;
            position.z += moveSpeed * vertical * Time.fixedDeltaTime;
        }

        // Jump handling
        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                // Force quit the hold-jump when reaching the limit
                jumpHoldTimer += Time.fixedDeltaTime;
                if (jumpHoldTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }

            position.y += velocity.y * Time.fixedDeltaTime;
            
            // Make the gravity do its job when the player is not holding jump
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }
        }

        // Set a new position
        transform.position = position;
    }
}
