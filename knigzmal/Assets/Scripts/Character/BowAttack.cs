using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : MonoBehaviour
{
    private bool IsOwner = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("Bow Attack: No animator found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("BowAttacking", true);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                animator.SetBool("BowAttacking", false);
            }
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot");
    }
}
