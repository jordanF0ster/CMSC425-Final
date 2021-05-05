using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{

    Vector3 dist;
    float lookSpeed = 2f;
    public float moveSpeed = 50f;
    Rigidbody rb;
    Enemy e;
    //float closeDist = 10f;
    float startHeight;
    //float weaponRange;
    PauseManager pm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        e = this.GetComponent<Enemy>();
        dist = transform.position - e.player.transform.position;
        startHeight = transform.position.y;

        pm = e.player.GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pm.isPaused())
        {
            rb.velocity = Vector3.zero;
            //maintainDist();
            pointAtPlayer();
            moveToPlayer();
            if (transform.position.y != startHeight)
                maintainHeight();
        }
    }

    private void pointAtPlayer()
    {


        Vector3 direction = e.player.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime);
        Quaternion quat = transform.rotation;
        quat.eulerAngles = new Vector3(0, quat.eulerAngles.y, 0);
        transform.rotation = quat;
    }

    public void moveToPlayer()
    {
        Vector3 direction = transform.forward;
        Vector3 realDirection = new Vector3(direction.x, transform.position.y, direction.z);
        rb.AddForce(direction * moveSpeed);
    }

    private void maintainHeight()
    {
        Vector3 tPos = transform.position;
        Vector3 pos = new Vector3(tPos.x, startHeight, tPos.z);
        transform.position = Vector3.Lerp(tPos, pos, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player" || collision.collider.name == "Blaster" && !pm.isPaused())
        {
            Debug.Log("HIT");
            e.player.damage(1);
        }
    }
}
