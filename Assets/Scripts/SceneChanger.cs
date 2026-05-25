using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //Variables
    public string loadMainLevel = "MainLevel"; // these store a string variable to use to load the respective sceenes
    public string mainMenuName = "MainMenu";
    public string helpMenu = "HelpMenu";
    public string costumeMenu = "CostumeMenu";

    public GameObject pauseMenu; // stores the pausemenu GO
    public GameObject page1; // stores the page1 GO
    public GameObject page2; // stores the page2 GO
    public GameObject gameOverScreen; // stores the gameOver panel


    public void StartGame()
    {
        SceneManager.LoadScene(loadMainLevel); // loads level1
        Time.timeScale = 1f; // timescale is static and needs to be updated everywhere
        gameObject.SetActive(false);
       

    }// end of start game function

    public void RestartGame()
    {
        SceneManager.LoadScene(loadMainLevel); // loads level1
        Time.timeScale = 1f; // timescale is static and needs to be updated everywhere
        gameOverScreen.SetActive(false); // deactivates the game over screen


    }// end of restart

    public void QuitGame()
    {
        Application.Quit(); // Exits the game in build mode only

    }// end of quit game function

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenuName); // loads the mainmenu scene

    }// end of quit function

    public void Help()
    {
        SceneManager.LoadScene(helpMenu); // loads the helpMenu

    }// end of quit function

    public void Costume()
    {
        SceneManager.LoadScene(costumeMenu); // loads the costumeMenu

    }// end of quit function

    public void Pause()
    {
        pauseMenu.SetActive(true); // the pause panel is activated
        Time.timeScale = 0f; // timescale is turned off when the game is paused
    } // end of pause

    public void Resume()
    {
        pauseMenu.SetActive(false); // pause panel is deactivated
        Time.timeScale = 1f; // time resumes when the pause menu is closed
    } // end of resume

    public void Next()
    {
        page1.SetActive(false); // deactivates the page1 GO
        page2.SetActive(true); // and activates the page2 GO

    } // end of next

    public void Previous()
    {
        page1.SetActive(true); // activates the page1 GO
        page2.SetActive(false); // and unactivates the page2 GO

    } // end of previous

} // end of class
