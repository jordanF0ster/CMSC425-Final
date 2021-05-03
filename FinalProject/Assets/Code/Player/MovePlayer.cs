using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 10f; // movement speed
    public float sensitivity = 100; // camera sensitivity


    Vector3 dashDirection; // vector pointing towards last faced direction for dash
    float dashSpeed = 30f; // default dash speed
    bool isDashing = false;

    Rigidbody rb;

    // for dash effect
    private LineRenderer line;
    Vector3 move;
    Vector3 pos;
    private AudioSource source;

    PauseManager pm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();
        source = GetComponent<AudioSource>();
        pm = GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pm.isPaused())
        {
            // have player look at mouse by pointing ray in direction
            Vector3 mousePos = Input.mousePosition;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit))
            {
                Vector3 target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(target);
            }

            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }

    void FixedUpdate()
    {
        movePlayer(move);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.Play();
            StartCoroutine(dash());
        }
    }

    // for better collisions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Starting Room")
        {
            rb.velocity = Vector3.zero;
        }
    }

    // Dash forward by translating position then setting velocity to 0
    // player must wait a certain number of seconds before they can dash again
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
        float oldSpeed = speed;
        speed = dashSpeed;
        yield return new WaitForSeconds(0.1f);
        speed = oldSpeed;

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

    // move by rigid body
    void movePlayer(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
