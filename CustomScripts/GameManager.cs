/*
    GameManager.cs - script will hold info for players score, what to do in levels based on that score (example: start/end level, restart level, etc.)

    v1: keeps track of players actual scores for the three minigames + shows up on text display in game

 find a way to reference duck score script to set players score in GameManager script
     */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{


    bool gameHasEnded = false;

    public float restartDelay = 1f;

    //Added for final project: player scores for Duck Hunt, Tomato Toss, Wall Climb
    //These values will hold the actual score for the player
    public int playerScoreDH, playerScoreTT;
    public double playerScoreWC;
    
    public int highscoreDH, highscoreTT;
    public double highscoreWC;
    //These variables hold the text to be displayed
    public TMP_Text DuckHuntScoreText, TomatoTossScoreText, WallClimbTimerText;
    

    /*
    //Reference LevelCompletePanel 
    public GameObject LevelCompletePanelUI;

    //Reference LevelLosePanel
    public GameObject LevelLosePanelUI;
    */



    void Start()
    {
        StaticGM.gm = this;
        //Player's score for each minigame should start at 0
        playerScoreDH = 0;
        playerScoreTT = 0; 
        playerScoreWC = 0.0;
         
    }

    void Update()
    {

        if (DuckHuntScoreText.isActiveAndEnabled)
        {
            if(playerScoreDH>highscoreDH)
            {
                highscoreDH = playerScoreDH;
            }
            //Updates the score text to players score in the minigame
            DuckHuntScoreText.text = "Score: " + playerScoreDH.ToString() + "\nHighScore: " + highscoreDH.ToString();
        }
        if(!DuckHuntScoreText.isActiveAndEnabled)
        {
            playerScoreDH = 0;
        }

        //to be implemented
        if (TomatoTossScoreText.isActiveAndEnabled)
        {
            if(playerScoreTT>highscoreTT)
            {
                highscoreTT = playerScoreTT;
            }
            //Updates the score text to players score in the minigame
            TomatoTossScoreText.text = "Score: " + playerScoreTT.ToString() + "\nHighScore: " + highscoreTT.ToString();
        }
        if (!TomatoTossScoreText.isActiveAndEnabled)
        {
            playerScoreTT = 0;
        }

        if (WallClimbTimerText.isActiveAndEnabled)
        {
            playerScoreWC += Time.deltaTime;
            //Updates the score text to players score in the minigame
            WallClimbTimerText.text = "Time: " + playerScoreWC.ToString("F2") + "\nBestTime: " + highscoreWC.ToString("F2");
            
        }
        

        if (!WallClimbTimerText.isActiveAndEnabled)
        {
            playerScoreWC = 0;
        }

    }

    public void EndGame()
    {
        //If game end triggered, set to true and restart level
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }




    //Reloads current scene
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




    //Do things when level is completed
    //Display image, effects, sounds, text, etc. on a screen
    public void CompleteLevel()
    {
        //Debug.Log("You won!");
        //LevelCompletePanelUI.SetActive(true);
    }

    //Do things when losing the level
    //Debug is just for testing purposes
    public void LoseLevel()
    {
        //Debug.Log("You lose.");
       //LevelLosePanelUI.SetActive(true); //sets LevelLose UI active -> play animation
    }



    //Keeps track of score in this script (GameManager.cs) - new version WIP
    public void IncrementDHScore()
    {
        playerScoreDH++;
    }

    public void IncrementTTScore()
    {
        playerScoreTT++;
    }


    public void pushHighscoreWC()
    {
        if(highscoreWC == 0.00)
        {
            highscoreWC = playerScoreWC;
        }
        else if(playerScoreWC < highscoreWC)
        {
            highscoreWC = playerScoreWC;
        }
        
    }

}

