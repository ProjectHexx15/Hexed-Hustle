using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpellMovement : MonoBehaviour
{
    // variables
    public int SpellSpeed; // stores how fast the spell travels across the screen
    public int CandyAmount; // publicaly stores the candy amount to add so that it can be changed for each enemy type
    private EnemyHealth EH; // stores the enemyHealth script as EH
    


    private void Start()
    {
        EH = GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>(); // finds the player GO and gets the PlayerHealth component
       
    } // end of start


    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * SpellSpeed); // sends the magic towards the right of the screen

        if (transform.position.x >= 12) // 12 is the boundary number for x axis
        {
            Destroy(gameObject); // destorys magic projectile if it goes out of screen
        }


    } // End of Update

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // if the enemy collides with the player
        {
          
            EH.EnemyTakesDamage(); // the enemy is damaged
            Destroy(this.gameObject); // spell is destroyed after defeating an enemy
        
            
        }
        

    }


} // end of class
