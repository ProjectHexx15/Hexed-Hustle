using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    // variables
    public GameObject[] skins; // stores the list of skins
    public int selectedCharacter; // stores the number of the currently selected character

    public Character[] characters; // creates an array of the character class
    public Button unlockButton; // stores the unlock button GO

    public TextMeshProUGUI candyText; // stores the candy text GO
   


    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0); // stores the current costume using player prefs

        foreach(GameObject player in skins) // checks each costumein the list
        {
            player.SetActive(false); // deactivates the skins we arnt using

            skins[selectedCharacter].SetActive(true); // activates the character that has been selected

            foreach(Character c in characters) // loops through each character in the Characters array
            {
                if(c.price == 0) // if the character cost nothing (Base costume will be free)
                {
                    c.isUnlocked = true; // the character is unlocked
                }
                else
                {
                    if(PlayerPrefs.GetInt(c.name, 0) == 0) // if the character is not for free
                    {
                        c.isUnlocked = false; // the character is not unlocked
                    }
                    else
                    {
                        c.isUnlocked= true; // the character is unlocked
                    }
                }
            } // end of for each characters

        } // end of for each skins

        UpdateUI(); // calls the update ui function when the scene is loaded
    } // end of awake

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false); // deactivates the player that was selected previously
        selectedCharacter++; // adds one to the selected character variable which will change it too the next costume

        if(selectedCharacter == skins.Length) // if we have reached the last character
        {
            selectedCharacter = 0; // resets the selectted character when the player reaches the end
        }

        skins[selectedCharacter].SetActive(true); // activates the new updated character
        
        if (characters[selectedCharacter].isUnlocked) // checks if the selected character is playable
        {
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter); // selects this character if it is playable
        }
        UpdateUI(); // calls the update ui function when a character is swapped
    } // end of ChangeNext

    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false); // deactivates the player that was selected previously
        selectedCharacter--; // adds one to the selected character variable which will change it too the next costume

        if (selectedCharacter == -1) // if we have reached the last character
        {
            selectedCharacter = skins.Length -1; // resets the selectted character when the player reaches the end
        }

        skins[selectedCharacter].SetActive(true); // activates the new updated character
        if (characters[selectedCharacter].isUnlocked) // checks if the selected character is playable
        {
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter); // selects this character if it is playable
        }
        UpdateUI(); // calls the update ui function when a character is swapped
    } // end of ChangeNext

    public void UpdateUI()
    {
        candyText.text = PlayerPrefs.GetInt("totalCandy").ToString(); // gets the total candy count and displays it

        if (characters[selectedCharacter].isUnlocked == true) // if the current character is unlocked
        {
            unlockButton.gameObject.SetActive(false); // hides the button if the player owns this costume
        }
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + characters[selectedCharacter].price; // gets the text child object from the button and displays the price of the current costume
            if (PlayerPrefs.GetInt("totalCandy", 0) < characters[selectedCharacter].price) // if the total amount of candy is less than the costumes price
            {
                unlockButton.gameObject.SetActive(true); // player is able to see the button however doesnt have enough to buy
                unlockButton.interactable = false; // player can see how much the costume costs but cant purchase it
                // so that they cant go into minus candy or get it when they dont have enough
            }
            else
            {
                unlockButton.gameObject.SetActive(true); // player has enough
                unlockButton.interactable = true; // and can press the button to purchase
            }

        }

    } // end of UpdateUI

    public void Unlock()
    {
        int candy = PlayerPrefs.GetInt("totalCandy", 0); // stores the candy total as candy
        int price = characters[selectedCharacter].price; // stores the price of the current characacter as price
        PlayerPrefs.SetInt("totalCandy", candy - price); // updates the candy by taking away the price amount of candy
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1); // changes the unlock boolean to true
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter); // changes the selected character in the main level
        characters[selectedCharacter].isUnlocked = true;  // changes the boolean to unlcoked
        UpdateUI(); // calls the update ui function when a character is unlocked
    } // end of Unlock


} // end of class
