using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// camera always points at weapon shoot distance in blaster
// should be positioned so crosshairs are always where max range of weapon is

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
