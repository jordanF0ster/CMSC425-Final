using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

// a death menu pops up when the player has reached 0 health (hearts)
// from this menu the player can either restart or they can quit the game
public class DeathMenu : MonoBehaviour
{
    private Button restartButton; // to restart game
    private Button quitButton; // to quit game entirely
    DeathManager dm;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDeathManager(DeathManager manager)
    {
        restartButton = GameObject.FindGameObjectWithTag("DeathRestartButton").GetComponent<Button>();
        quitButton = GameObject.FindGameObjectWithTag("DeathQuitButton").GetComponent<Button>();

        dm = manager;

        quitButton.onClick.AddListener(dm.quitGame);
    }
}
