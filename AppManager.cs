/*
 *  Currently disabled, needs to be implemented for final
 *  Things to implement
 */ 


/*
 * Debug Logs are only used for testing purposes, remember to uncomment when needed.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AppManager : MonoBehaviour
{
    //Each stage = an event; this will show up in the INSPECTOR to handle objects/functions
    public UnityEngine.Events.UnityEvent onLoadStage2;
    public UnityEngine.Events.UnityEvent onLoadStage3;

    //AppStates - where each stage goes
    private enum AppStates
    {
        Stage1Intro, //Intro can be where text is displayed to tell the player the background story, like an opening cutscene
        Stage2Main,  //Main can be where objects + enemies spawn in -> Use GameObject.SetActive
        Stage3Closing
    }
    AppStates myAppState;

    public GameManager gameManager;

    public TMP_Text VrText;
    public TMP_Text DebugText2D;

    bool readyToEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        myAppState = AppStates.Stage1Intro; //Start in Stage 1
        VrText.text = "Stage 1.";
        DebugText2D.text = "In stage 1: Intro (press SPACE to proceed).";

    }

    // Update is called once per frame
    void Update()
    {
        switch (myAppState)
        {
            //Stage 1
            case AppStates.Stage1Intro:

                //Debug.Log("Stage 1");

                VrText.text = "Test out the Duck Hunt Gallery!"; //Intro text to be displayed at start of the game

                //Consider replacing KeyCode.Space with a button press on VIVE Controllers/VR Controllers
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    DebugText2D.text = "Duck Hunt Gallery minigame enabled!";
                    onLoadStage2.Invoke(); //triggers Stage 2 -> transition to Stage 2

                    myAppState = AppStates.Stage2Main;
                }
                break; //end of Stage 1


            //Stage 2
            case AppStates.Stage2Main:

                //Debug.Log("Stage 2");

                if (gameManager.playerScoreDH >= 30)
                {
                    DebugText2D.text = "The player scored enough points. Press space to proceed.";
                }

                if (Input.GetKeyDown(KeyCode.Space) & (gameManager.playerScoreDH >= 30))
                {
                    DebugText2D.text = "Transition to stage 3! Closing";

                    onLoadStage3.Invoke();

                    myAppState = AppStates.Stage3Closing;
                }
                break;

            //Stage 3 - play music, end credits, etc.
            case AppStates.Stage3Closing:

                //Debug.Log("Stage 3");

                //VrText.text = "You did it!";
                gameManager.CompleteLevel(); //signal player that they won
                break;
        }




    }


    //Unused for now
    public void onReadyToEnd(bool ready)
    {
        readyToEnd = ready;
    }
}
