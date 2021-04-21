using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float yAxisRotation = 0;
    public float speed = 0.25f; // movement speed
    public float sensitivity = 100; // camera sensitivity


    Vector3 dashDirection; // vector pointing towards last faced direction for dash
    public float dashSpeed = 5; // default dash speed

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        // rotation around y axis
        yAxisRotation += sensitivity * Time.deltaTime * Input.GetAxis("Mouse X");

        Quaternion yQuatern = Quaternion.Euler(0, yAxisRotation, 0);
        transform.rotation = yQuatern;

        // basic wasd movement
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += transform.forward * speed;
            dashDirection = transform.forward;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.position -= transform.right * speed;
            dashDirection = -1 * transform.right;
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            transform.position -= transform.forward * speed;
            dashDirection = -1 * transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed;
            dashDirection = transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("DASH");
            StartCoroutine(dash());
        }
    }

    // Dash forward by translating position then setting velocity to 0
    public IEnumerator dash()
    {
        // rb.AddForce(dashDirection * dashSpeed, ForceMode.VelocityChange);

        transform.position += dashDirection * dashSpeed;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(3);

        rb.velocity = Vector3.zero;
    }
}
