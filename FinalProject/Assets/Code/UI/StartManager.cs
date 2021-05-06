using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    Canvas canvas;
    public StartMenu menu; // prefab
    private StartMenu instMenu; // instantiated menu
    private PauseManager pm;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMenu()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        instMenu = Instantiate(menu, canvas.transform);
        pm = GetComponent<PauseManager>();
        pm.pauseByDeath();

        instMenu.setStartManager(this);
    }

    public void startGame()
    {
        Destroy(instMenu.gameObject);
        pm.pauseByDeath();
    }

    public void learnHowToPlay()
    {

    }

    public void quitGame()
    {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
