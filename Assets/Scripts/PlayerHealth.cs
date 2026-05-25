using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    // variables
    public int health; // stores the players current health
    public int maxHealth; // stores the players maximum health

    public static PlayerHealth Instance; // creates a public instance of this script
    
    public UnityEvent playerIsDamaged; // creates a public unity event for when the player is damaged
    public Player player; // references the player class object
    public bool isDefeated; // stoores a boolean variable for weather or not the player is defeated

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; // resets the players health at the start of the game
        isDefeated = false; // resets the isDefeated bool

    } // end of start

    public void TakeDamage()
    {
        playerIsDamaged.Invoke(); // invokes the playerdamaged event
        health -= 1; // player looses one health point
        if (health <= 0) // if the player looses all of their lives
        {
            isDefeated = true; // sets this bool variable to "true" when the player is defeated
            Time.timeScale = 0f; // time is paused whilst this screen is open
        }
    } // end of take damage


} // end of class
