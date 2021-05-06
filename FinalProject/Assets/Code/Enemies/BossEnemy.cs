using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
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
        base.mark();
    }

    public void unMark()
    {
        Debug.Log("HIT@UM");
        base.marked = false;
        mesh.material = origMaterial;
    }
}
