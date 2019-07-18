using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float InitialMoveSpeed = 2f;
    public float MoveSpeed = 2f;
    public float MaxMoveSpeed = 10f;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }
        Vector2 velocity = rb.velocity;
        if (Mathf.Abs(rb.velocity.x) <= InitialMoveSpeed)
        {
            velocity.x = horizontalInput * InitialMoveSpeed;
        }
        else if (Mathf.Abs(rb.velocity.x) >= MaxMoveSpeed)
        {
            velocity.x = horizontalInput * MaxMoveSpeed;
        }
        else
        {
            velocity.x += horizontalInput * MoveSpeed * Time.deltaTime;
        }
        rb.velocity = velocity;
    }
}
