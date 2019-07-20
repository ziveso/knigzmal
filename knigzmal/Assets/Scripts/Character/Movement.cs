using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float JumpHeight = 2f;
    private bool isFaceRight = true;
    private bool IsOwner = true;

    public Vector3 groundCheckCenter;
    public Vector3 groundCheckSize;
    public LayerMask whatIsGround;
    public bool IsGrounded;

    private Animator animator;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.y <= 0)
        {
            // make it fall faster;
            rb.velocity -= new Vector2(0, 0.1f);
        }
        if (IsOwner)
        {
            MoveVertical();
            MoveHorizontal();
            CheckGround();
        }
        ChangeDirection();
        if (rb.velocity.x != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * MoveSpeed, rb.velocity.y);
    }

    private void MoveVertical()
    {
        if (Input.GetAxisRaw("Vertical") == 1 && IsGrounded)
        {
            Jump();
        }
    }

    private void CheckGround()
    {
        IsGrounded = Physics2D.OverlapArea(
            new Vector2(transform.position.x + groundCheckCenter.x - groundCheckSize.x,
                        transform.position.y + groundCheckCenter.y - groundCheckSize.y),
            new Vector2(transform.position.x + groundCheckCenter.x + groundCheckSize.x,
                        transform.position.y + groundCheckCenter.y + groundCheckSize.y),
            whatIsGround);

        Debug.DrawLine(new Vector2(transform.position.x + groundCheckCenter.x - groundCheckSize.x,
                            transform.position.y + groundCheckCenter.y - groundCheckSize.y),
                        new Vector2(transform.position.x + groundCheckCenter.x + groundCheckSize.x,
                            transform.position.y + groundCheckCenter.y + groundCheckSize.y), Color.red);
    }

    private void ChangeDirection()
    {
        if (rb.velocity.x > 0 && !isFaceRight)
        {
            Flip();
        }
        if (rb.velocity.x < 0 && isFaceRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
    }
}
