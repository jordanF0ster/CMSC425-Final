using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRanged : MonoBehaviour
{
    Vector3 dist;
    float lookSpeed = 2f;
    float moveSpeed = 50f;
    Rigidbody rb;
    Enemy e;
    float closeDist = 10f;
    float startHeight;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        e = this.GetComponent<Enemy>();
        dist = transform.position - e.player.transform.position;
        startHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        if (Vector3.Distance(e.player.transform.position, transform.position) < closeDist)
        {
            maintainDist();
        }
        pointAtPlayer();
        Debug.Log("TR: " + transform.transform.rotation.eulerAngles.x + ", " + transform.transform.rotation.eulerAngles.z);
        //if (transform.localEulerAngles.x > 1 || transform.localEulerAngles.z != 0)
        //    maintainRotation();
        //else
        //    pointAtPlayer();

        if (transform.position.y != startHeight)
            maintainHeight();
    }

    private void pointAtPlayer()
    {
        //rb.MovePosition(e.player.transform.position + dist);
        //transform.position = Vector3.Lerp(transform.position, e.player.transform.position + dist, speed * Time.deltaTime);
        //transform.LookAt(e.player.transform);

        
        Vector3 direction = e.player.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime);
        Quaternion quat = transform.rotation;
        quat.eulerAngles = new Vector3(0, quat.eulerAngles.y, 0);
        transform.rotation = quat;
    }


    private void maintainHeight()
    {
        RaycastHit hit;

        //if (Physics.Raycast(transform.position, Vector3.down, out hit)) {
        //    1 + 1;
        //}
        Vector3 tPos = transform.position;
        Vector3 pos = new Vector3(tPos.x, startHeight, tPos.z);
        transform.position = Vector3.Lerp(tPos, pos, moveSpeed * Time.deltaTime);
    }

    private void maintainDist()
    {
        Vector3 direction = -1 * transform.forward;
        Vector3 realDirection = new Vector3(direction.x, transform.position.y, direction.z);

        rb.AddForce(direction * moveSpeed);

        //transform.position = Vector3.Lerp(transform.position, realDirection, moveSpeed * Time.deltaTime);
    }

    private void maintainRotation()
    {
        //Vector3 direction = e.player.transform.position - transform.position;
        //transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime);
        ////Vector3 direction2 = new Vector3(0, direction.transform.rotation.y, 0);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
    }
}
