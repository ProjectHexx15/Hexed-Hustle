using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // variables
    float randomPos; // stores the randomly generate spawn pos (between the games boundaries
    Vector2 spawnPosition; // stores the enemies spawn pos
    public float spawnRate =  2.0f; // the spawn rate of enemies
    private float nextSpawn = 0.0f; // stores when the next spawn will take place

    public List<GameObject> enemyList; // stores the spawned enemies onto this list
    private GameObject randomEnemy; // this will store a random enemy prefab GO

    private GameObject RandomEnemy()
    {
        var random_temp = UnityEngine.Random.Range(0, enemyList.Count); // stores a random number from the enemy list (out of 3)
        // unityengine.random vs system.random
        // unity engine is static? will work better for this i think

        for (int i = 0; i < enemyList.Count; i++) // loops through list to find the enemy number generarted  
        {
            if (i == random_temp) // if number is the random number
            {
                randomEnemy = enemyList[i]; // sets random enemy to the one in the list (the random enemy type)
            } // end of if
        } // end of for

        return randomEnemy;
    } // end of random enemy (will return a GO)

    private void SpawnEnemy()
    {
        if (Time.time > nextSpawn) // checks if able to spawn an enemy
        {
            nextSpawn = Time.time + spawnRate; // adds the spawnrate to next spawn for this check
            randomPos = UnityEngine.Random.Range(-3.05f, 2.68f); // spawns enemy in a random pos in the Y axis within the screen boundaries
            spawnPosition = new Vector2(12f, randomPos); // stores the enemies spawn position
            Instantiate(RandomEnemy(),spawnPosition, Quaternion.identity, this.transform); // spawns the enemy instance at this position
        }

    } // end of SpawnEnemy

    private void Update()
    {
        SpawnEnemy();
    } // end of update


} // end of class
