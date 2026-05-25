using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // variables
    public int enemyHealh; // stores the enemies current health points
    public int maxEnemyHealth; // stores the enemies maximum

    public static EnemyHealth Instance; // creates a public instance of this script

    // Start is called before the first frame update
    void Start()
    {
        enemyHealh = maxEnemyHealth; // resets the enemys health when they are spawned
        
    } // end of start
    public void EnemyTakesDamage()
    {
        enemyHealh -= 1; // player looses one health point
        if (enemyHealh <= 0) // if the player looses all of their lives
        {
            
            Destroy(gameObject); // Destroys the enemy GO
            ScoreManager.instance.AddScore(); // adds the appropriate amount to the players score   
            ScoreManager.instance.AddCandy(); // adds the appropriate amount to the players total candy
        }
    } // end of EnemyTakesDamage

} // end of class
