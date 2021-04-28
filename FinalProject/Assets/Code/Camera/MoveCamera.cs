using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// camera always points at weapon shoot distance in blaster
// should be positioned so crosshairs are always where max range of weapon is

public class MoveCamera : MonoBehaviour
{

    public Player target;
    public Vector3 dist;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        //dist = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + dist, speed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}
