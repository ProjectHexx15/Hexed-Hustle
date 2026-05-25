using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // variables
    public float movementSpeed; // stores the players movement speed
    private Vector3 targetPos; // the target position we want to move too

    public void Move (Vector3 moveDirection)
    {
        targetPos += moveDirection; // move the target position in the direction that was swiped
    } // end of Move

    void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime); // returns and updates the players new position once they have moved

    } // end of update

} // end of class
