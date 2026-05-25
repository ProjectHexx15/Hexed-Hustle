using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.80f, 7.80f), Mathf.Clamp(transform.position.y, -3.05f, 2.68f), transform.position.z);
        // mathF clamps the x and y pos between two max and min numbers, this keeps the player within the screen bounds
    }
} // end of class
