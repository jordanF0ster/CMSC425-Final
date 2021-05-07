using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    private Button restartButton; // to restart game
    private Button quitButton; // to quit game entirely
    WinManager wm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setDeathManager(WinManager manager)
    {
        restartButton = GameObject.FindGameObjectWithTag("WinRestartButton").GetComponent<Button>();
        quitButton = GameObject.FindGameObjectWithTag("WinQuitButton").GetComponent<Button>();

        wm = manager;

        quitButton.onClick.AddListener(wm.quitGame);
        restartButton.onClick.AddListener(wm.restartGame);
    }
}
