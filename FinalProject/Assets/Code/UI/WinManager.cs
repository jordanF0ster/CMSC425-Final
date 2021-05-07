using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    Canvas canvas;
    public WinMenu menu; // prefab
    private WinMenu instMenu; // instantiated menu
    private GenBossRoom room; // needed because this is not attached to the player but the final boss spawner instead
    private PauseManager pm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMenu()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        instMenu = Instantiate(menu, canvas.transform);
        room = GetComponent<GenBossRoom>();
        pm = room.player.GetComponent<PauseManager>();
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
