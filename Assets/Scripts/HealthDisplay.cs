using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // variables
    public int health; // stores the players current health
    public int maxHealth; // stores the player maximum health

    public Sprite emptyHeart; // stores the empty heart sprite
    public Sprite fullHeart; // stores the full heart sprite
    public Image[] hearts;

    public PlayerHealth playerHealth; // references the playerHealth script
    public Player player; // references the player object type

    // Update is called once per frame
    void Update()
    {
        player = FindAnyObjectByType<Player>(); // finds the player object

       PlayerHealth playerHealth = FindAnyObjectByType<PlayerHealth>(); // finds the PlayerHealth script on the player Object

        for (int i =0; i < hearts.Length; i++)
        {
            health = playerHealth.health; // constantly updates this health with the other health value
            maxHealth = playerHealth.maxHealth; // constantly updates this maxHealth with the other maxHealth value

            if(i < health) // checks each heart to see if it should be full or empty
            { //
                hearts[i].sprite = fullHeart; // player has the heart
            }
            else
            {
                hearts[i].sprite = emptyHeart; // health is not there
            }

            if(i < maxHealth) // checks if int is less than maxHealth
            { // if yes
                hearts[i].enabled = true; //takes the hearts sprite and enables it
            }
            else
            { // if health is less then max
                hearts[i].enabled = false; // turns of the sprites that shoudnt be enabled
            }

        } // end of for

    } // end of update

} // end of class
