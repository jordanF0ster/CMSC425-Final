using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pauseGame();
    }

    // pauses game if keycode matches
    private void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = paused ? 1f : 0f;
            paused = !paused;
        }
    }

    public bool isPaused()
    {
        return paused;
    }
}
