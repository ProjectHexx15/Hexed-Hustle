using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    // variables
    public GameObject[] playerPrefabs; //creates an array that will hold each player prefab
    int characterIndex; // stores an int value that will store the characterIndex
    private PlayerHealth PH; // stores the PlayerHealth script in this script as PH
    public GameObject GOpannel; // stores the game over pannel as a GO
    public GameObject SpawnPos; // stotres the position that the player will spawn at

    public void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0); // stores which player is currently selected
        GameObject player = Instantiate(playerPrefabs[characterIndex], SpawnPos.transform.position, Quaternion.identity); // makes an instance of the selected player GO at the specified position (startPos)
    } // end of awake

    private void Start()
    {
        PH = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>(); // finds the player GO and gets the PlayerHealth component

    } // end of start

    private void Update()
    {
        if(PH.health <= 0) // if the player has died
        {
            GOpannel.SetActive(true); // activates the game over pannel
        }
    } // end of update

} // end of class
