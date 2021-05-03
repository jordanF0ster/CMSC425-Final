using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject heart;
    GameObject[] heartList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showHearts(int numHearts)
    {
        if (heartList != null)
            destroyOldHearts();

        heartList = new GameObject[numHearts];
        for (int i = 0; i < numHearts; i++)
        {
            GameObject h = Instantiate(heart, transform);
            heartList[i] = h;
        }
    }

    private void destroyOldHearts()
    {
        foreach (GameObject x in heartList)
            Destroy(x.gameObject);
    }
}
