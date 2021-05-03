using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// script for enemy marking system

public class Enemy : MonoBehaviour
{
    public int health;
    bool marked = false;
    MeshRenderer mesh;
    public Material markedMaterial;
    public Player player;
    PauseManager pm;
    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        pm = player.GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mark()
    {
        if (!marked && !pm.isPaused())
        {
            marked = true;
            mesh.material.color = markedMaterial.color;
        }
    }

    public bool isMarked()
    {
        return marked;
    }
}
