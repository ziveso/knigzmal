using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool IsOwner = true;
    private PlatformEffector2D platformEffector2D;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        platformEffector2D = GetComponent<PlatformEffector2D>();
        if (platformEffector2D == null)
        {
            Debug.LogWarning("Platform: No platform effector 2d");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                platformEffector2D.rotationalOffset = 180;
            }

            if (Input.GetAxisRaw("Vertical") == 1)
            {
                platformEffector2D.rotationalOffset = 0;
            }
        }
    }

    // /// <summary>
    // /// Sent when a collider on another object stops touching this
    // /// object's collider (2D physics only).
    // /// </summary>
    // /// <param name="other">The Collision2D data associated with this collision.</param>
    // void OnCollisionExit2D(Collision2D other)
    // {
    //     // other.gameObject.GetComponent
    //     if(IsOwner)
    //     {

    //     }
    // }
}
