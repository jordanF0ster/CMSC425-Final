using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float yAxisRotation = 0;
    public float speed = 0.25f;
    public float sensitivity = 100;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rigidbody rb = GetComponent<Rigidbody>();

        yAxisRotation += sensitivity * Time.deltaTime * Input.GetAxis("Mouse X");

        Quaternion yQuatern = Quaternion.Euler(0, yAxisRotation, 0);
        transform.rotation = yQuatern;

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * speed;
        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right * speed;
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * speed;
    }
}
