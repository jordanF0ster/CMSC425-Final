using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private Button startButton; // to restart game
    private Button howButton;
    private Button quitButton; // to quit game entirely
    StartManager sm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setStartManager(StartManager manager)
    {
        startButton = GameObject.FindGameObjectWithTag("StartGameButton").GetComponent<Button>();
        howButton = GameObject.FindGameObjectWithTag("StartHowButton").GetComponent<Button>();
        quitButton = GameObject.FindGameObjectWithTag("StartQuitButton").GetComponent<Button>();

        sm = manager;

        startButton.onClick.AddListener(sm.startGame);
        howButton.onClick.AddListener(sm.learnHowToPlay);
        quitButton.onClick.AddListener(sm.quitGame);
    }
}
