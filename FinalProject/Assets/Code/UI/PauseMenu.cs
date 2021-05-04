using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private Button resumeButton; // to resume game
    private Button quitButton; // to quit game entirely
    PauseManager pm;

    // Start is called before the first frame update
    void Start()
    {
        //resumeButton = GameObject.FindGameObjectWithTag("PauseResumeButton").GetComponent<Button>();
        //quitButton = GameObject.FindGameObjectWithTag("PauseQuitButton").GetComponent<Button>();
        //foreach (Transform child in transform)
        //{
        //    //child is your child transform
        //    //print("CCC: " + child);
        //    if (child.tag == "PauseResumeButton")
        //        resumeButton = child.GetComponent<Button>();
        //    if (child.tag == "PauseQuitButton")
        //        quitButton = child.GetComponent<Button>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPauseManager(PauseManager manager)
    {
        resumeButton = GameObject.FindGameObjectWithTag("PauseResumeButton").GetComponent<Button>();
        quitButton = GameObject.FindGameObjectWithTag("PauseQuitButton").GetComponent<Button>();
        pm = manager;

        resumeButton.onClick.AddListener(pause);
        quitButton.onClick.AddListener(quit);
    }

    private void pause()
    {
        pm.pauseGameFromMenu(this);
    }

    private void quit()
    {
        pm.quitGame();
    }

}
