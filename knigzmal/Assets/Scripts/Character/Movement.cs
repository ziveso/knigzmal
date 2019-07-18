using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float JumpHeight = 2f;
    private bool isFaceRight = true;
    private bool isOwner = true;

    [SerializeField]
    Vector3 groundCheckCenter;
    [SerializeField]
    Vector3 groundCheckSize;
    [SerializeField]
    LayerMask whatIsGround;
    public bool IsGrounded;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOwner)
        {
            MoveVertical();
            MoveHorizontal();
            CheckGround();
        }
        ChangeDirection();
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
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
    }
}
