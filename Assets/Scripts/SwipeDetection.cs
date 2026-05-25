using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    // Variables
    public Player player; //stores the player object
    private Vector2 startPos; //stores the starting touch position on the screen
    public int pixelDistToDetect = 20; // stores how many pixels beed to be swiped to move
    private bool fingerDown; // stores whent the players finger is touching the screen
    public float swipeDistance; // stores the multiplier for the players swipe distance
    private PlayerManager PM; // references the playermanager script

    private void Update()
    {
        player = FindAnyObjectByType<Player>();

        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) // if finger is currently not down & is it now on the screen & and is the first frame touching screen
        {
            startPos = Input.touches[0].position; // sets the starting touch position
            fingerDown = true; // finger is touching phone
        } // end of if

        if (fingerDown)
        {
            // directional detection
            //up
            if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect) // if the finger is swiping upwards
            {
                // move player up
                fingerDown = false;
                player.Move(Vector3.up * swipeDistance);
            }
            //up

            //down
            if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect) // if the finger is swiping downwards
            {
                // move player down
                fingerDown = false;
                player.Move(Vector3.down * swipeDistance);
            }
            //down

            //left
            else if (Input.touches[0].position.x <= startPos.x - pixelDistToDetect) // if the  finger swipes to the left
            {
                // move player left
                fingerDown = false;
                player.Move(Vector3.left * swipeDistance);
            }
            //left

            //right
            else if (Input.touches[0].position.x >= startPos.x + pixelDistToDetect) // if the finger swipes to the right
            {
                // move player right
                fingerDown = false;
                player.Move(Vector3.right * swipeDistance);
            }
            //right
   
        } // end of if

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) // when finger is lifted and released from the screen
        {
            fingerDown = false;
        }

    } // end of update

    public void Start()
    {
        PM = GameObject.FindWithTag("PlayerManager").GetComponent<PlayerManager>(); // finds the player GO and gets the PlayerHealth component
    } // end of start

} // end of class
