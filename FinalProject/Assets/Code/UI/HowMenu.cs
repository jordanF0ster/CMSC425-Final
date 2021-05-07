using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HowMenu : MonoBehaviour
{
    private Button backButton; // to quit game entirely
    HowManager hm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHowManager(HowManager manager)
    {
        backButton = GameObject.FindGameObjectWithTag("HowBackButton").GetComponent<Button>();

        hm = manager;
        backButton.onClick.AddListener(hm.back);
    }
}
