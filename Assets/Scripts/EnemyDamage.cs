using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth PH; // stores the PlayerHealth script in this script as PH
    public int EnemyScoreReward; // stores the amount of score that will be awarded to the player
    public int candyScoreReward;  // stores the amount of candy that will be awarded to the player
  
    public static EnemyDamage Instance; // creates a public static instance of this script
    

    private void Awake()
    {
        Instance = this; // ensures there is only one instance of this script    
    } // end of awake

    private void Start()
    {
        PH = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>(); // finds the player GO and gets the PlayerHealth component
      
    } // end of start

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // if the enemy collides with the player
        {
            PH.TakeDamage(); // acesses the playerHealth script and damages the player
         
        }
 
    } // end of collision detection



} // end of class
