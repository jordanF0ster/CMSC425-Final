using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// this class is attached to the player to detect when to display the death menu
public class DeathManager : MonoBehaviour
{
    Canvas canvas;
    public DeathMenu menu; // prefab
    private DeathMenu instMenu; // instantiated menu
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

        instMenu.setDeathManager(this);
    }

    private void destroyMenu()
    {
        if (instMenu != null)
        {
            Destroy(instMenu.gameObject);
        }
    }


    // restart game from beginning
    public void restartGame()
    {
        //Destroy(gameObject);
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject o in objects)
        {
            Destroy(o.gameObject);
        }
        Scene s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name, LoadSceneMode.Single);
        pm.pauseByDeath();
    }

    // quit game entirely
    public void quitGame()
    {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
