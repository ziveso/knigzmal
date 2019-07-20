using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject character;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, this.transform.position.z);
    }
}
