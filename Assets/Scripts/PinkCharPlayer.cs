using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkCharPlayer : MonoBehaviour
{
    public float movespeed;
    private Rigidbody2D rbP;
    private float HorIn;

    public float jumpforce;

    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    private bool IsGrounded;

    private SpriteRenderer sr;
    private Animator animator;


    void Start()
    {
        rbP = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);

        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }

        rbP.velocity = new Vector2(horizontalInput * movespeed, rbP.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded)
        {
            rbP.velocity = new Vector2(rbP.velocity.x, jumpforce);
        }

        if (horizontalInput < 0)
        {
            sr.flipX = false;
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = true;
        }
        animator.SetBool("isGrounded", IsGrounded);
        animator.SetFloat("speed",Mathf.Abs(rbP.velocity.x));
    }
}