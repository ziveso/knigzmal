using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        handleRunAnimation();
        handleJumpAnimation();
    }

    private void handleRunAnimation()
    {
        if (rb.velocity.x != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }

    private void handleJumpAnimation()
    {
        if (rb.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
            // anim.SetBool("IsFalling", false);
        }
        else if (rb.velocity.y > 0)
        {
            anim.SetBool("IsJumping", true);
            // anim.SetBool("IsFalling", false);
        }
        else
        {
            anim.SetBool("IsJumping", false);
            // anim.SetBool("IsFalling", true);
        }
    }
}
