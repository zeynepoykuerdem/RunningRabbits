using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCharPlayer : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isGrounded;

    private SpriteRenderer sp;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (horizontalInput < 0)
        {
            sp.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            sp.flipX = false;
        }
        animator.SetBool("?sGrounded", isGrounded);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

    }

}
