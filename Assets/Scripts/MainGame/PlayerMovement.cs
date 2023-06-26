using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Transform tr;
    private bool isJumping = false;
    private Vector3 turnLeft, turnRight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        turnLeft = tr.localScale;
        turnRight = tr.localScale;
        turnRight.x *= -1;
    }
    
    void Update()
    {
        // Moving left/right
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            tr.localScale = turnLeft;
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tr.localScale = turnRight;
            moveX = 1f;
        }

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            // isJumping = true; 
        }
    }
}
