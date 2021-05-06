using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// script for enemy marking system

public class Enemy : MonoBehaviour
{
    public int health;
    protected bool marked = false;
    protected MeshRenderer mesh;
    protected Material origMaterial; // original material
    public Material markedMaterial;
    public Player player;
    protected PauseManager pm;
    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        origMaterial = mesh.material;
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
            mesh.material = markedMaterial;
        }
    }

    public bool isMarked()
    {
        return marked;
    }
}
