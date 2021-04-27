using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float yAxisRotation = 0;
    public float speed = 10f; // movement speed
    public float sensitivity = 100; // camera sensitivity


    Vector3 dashDirection; // vector pointing towards last faced direction for dash
    float dashSpeed = 15f; // default dash speed
    bool isDashing = false;

    Rigidbody rb;

    // for dash effect
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        line = GetComponent<LineRenderer>();
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
            transform.position += transform.forward * speed * Time.deltaTime;
            dashDirection = transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
            dashDirection = -1 * transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
            dashDirection = -1 * transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
            dashDirection = transform.right;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(dash());
        //}
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(dash());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Starting Room")
        {
            rb.velocity = Vector3.zero;
        }
        //rb.velocity = Vector3.zero;
    }

    // Dash forward by translating position then setting velocity to 0
    public IEnumerator dash()
    {
        // break if already dashing
        if (isDashing)
        {
            yield break;
        }

        isDashing = true;
        line.enabled = true;


        line.SetPosition(0, transform.position);
        //Vector3 newPos = transform.position + (dashDirection * dashSpeed);
        float oldSpeed = speed;
        speed = dashSpeed;
        yield return new WaitForSeconds(0.1f);
        speed = oldSpeed;
        //line.SetPosition(0, transform.position);


        //transform.position += dashDirection * dashSpeed;
        

        line.SetPosition(1, transform.position);
        rb.velocity = Vector3.zero;

        // yield for dash effect
        yield return new WaitForSeconds(0.1f);
        line.enabled = false;

        // yield until you can dash again
        yield return new WaitForSeconds(0.5f);
        isDashing = false;

        
        rb.velocity = Vector3.zero;
    }
}
