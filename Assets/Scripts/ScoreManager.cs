using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    // variables
    public TMP_Text scoreText; // stores the scoreText GO
    public TMP_Text highScoreText; // stores the highScoreText GO
    public TMP_Text candyCountText; // stores the candycounttext GO

    int score = 0; // stores the players current score points
    int highScore = 0; // stores the players highScore
    public static int candyCount; // stores the players total candy count

    public static ScoreManager instance; // creates a public static instance of this script


    private void Awake()
    {
        instance = this; // ensures there is only one instance of this script 
       
    } // end of awake

    private void Update()
    {
        candyCountText.text = candyCount.ToString(); // converts the candy count to string and displays it on the screen
    } // end of update

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0); // sets the players initial high score
        scoreText.text = "SCORE: "; // resets the displayed score at the start of the game
        highScoreText.text = "HIGHSCORE: " + highScore.ToString(); // resets the displayed highscore at the start of the game

        candyCount = PlayerPrefs.GetInt("totalCandy");
       
    } // end of start

    public void AddScore()
    {
        score = score + EnemyDamage.Instance.EnemyScoreReward; // adds the respective enemy score points to the players score
        scoreText.text = "SCORE: " + score.ToString(); // updates the players score with how many points they currently have

        if (highScore < score) // ensures low score dont overright the highscore
        {
            PlayerPrefs.SetInt("highscore", score); // updates and stores the players high score
        }
    } // end of AddScore

    public void AddCandy()
    {
        candyCount = candyCount + EnemyDamage.Instance.candyScoreReward; // adds the specified amounr of candy to the players total amount when an enemy is defeated 
        PlayerPrefs.SetInt("totalCandy", candyCount); // updates the total candy count 
       
    } // end of AddCandy

} // end of class
