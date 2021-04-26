using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Blaster target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = target.transform.forward * target.shootDist;
        Vector3 lookPos = target.transform.position + fwd;
        transform.LookAt(lookPos);
    }
}
