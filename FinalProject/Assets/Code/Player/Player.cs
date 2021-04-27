﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || health <= 0)
        {
            Debug.Log("YOU ARE DEAD");
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public float getHealth()
    {
        return health;
    }

    public void addHealth(int x)
    {
        health += x;
    }

    public void damage(int x)
    {
        Debug.Log("DAMAGE");
        health -= x;
        
        //yield return new WaitForSeconds(1);
    }

    public Vector3 getPos()
    {
        return transform.position;
    }
}