using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    bool marked = false;
    MeshRenderer mesh;
    public Material markedMaterial;
    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mark()
    {
        if (!marked)
        {
            Debug.Log("IM HIT");
            marked = true;
            mesh.material.color = markedMaterial.color;
        }
    }
}
