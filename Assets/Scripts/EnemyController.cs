using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // variables
    public float EnemySpeed; // stores how fast the enemy will move

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * EnemySpeed); // sends the enemy left across the screen

        if (transform.position.x <= -12) // 12 is the boundary number for x axis
        {
            Destroy(gameObject); // destorys lazer if it goes out of screen
        }

    } // End of Update

} // end of class
