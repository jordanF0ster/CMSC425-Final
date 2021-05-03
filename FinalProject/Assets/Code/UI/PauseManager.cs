using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool paused = false;
    Canvas canvas;
    public PauseMenu menu; // prefab
    private PauseMenu instMenu; // instantiated menu

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        pauseWithKey();
    }

    // pauses game
    private void pauseGame()
    {
        if (!paused)
        {
            canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
            Time.timeScale = 0f;
            instMenu = Instantiate(menu, canvas.transform);
            instMenu.setPauseManager(this);
        }
        else
        {
            if (instMenu)
                Destroy(instMenu.gameObject);
            Time.timeScale = 1f;
        }
        paused = !paused;
    }

    // pause/unpause game if esc key hit
    private void pauseWithKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public bool isPaused()
    {
        return paused;
    }

    // only triggered from pause menu
    public void pauseGameFromMenu(PauseMenu menu)
    {
        pauseGame();
        Destroy(menu.gameObject);
    }

    // quits game entirely
    // only triggered from pause menu
    public void quitGame()
    {
#if UNITY_EDITOR
#else
        Application.Quit();
#endif
    }
}
