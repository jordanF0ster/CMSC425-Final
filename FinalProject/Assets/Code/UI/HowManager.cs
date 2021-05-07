using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowManager : MonoBehaviour
{
    Canvas canvas;
    public HowMenu menu; // prefab
    private HowMenu instMenu; // instantiated menu

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
        instMenu.setHowManager(this);
    }

    public void back()
    {
        Destroy(instMenu.gameObject);
    }
}
