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
    float weaponRange;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        e = this.GetComponent<Enemy>();
        dist = transform.position - e.player.transform.position;
        startHeight = transform.position.y;
        EnemyShoot es = GetComponent<EnemyShoot>();
        if (es != null)
            weaponRange = es.getRange();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        //if (Vector3.Distance(e.player.transform.position, transform.position) < closeDist)
        //{
        maintainDist();
        //}
        pointAtPlayer();

        if (transform.position.y != startHeight)
            maintainHeight();
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


    private void maintainHeight()
    {
        Vector3 tPos = transform.position;
        Vector3 pos = new Vector3(tPos.x, startHeight, tPos.z);
        transform.position = Vector3.Lerp(tPos, pos, moveSpeed * Time.deltaTime);
    }

    private void maintainDist()
    {
        Vector3 direction = Vector3.zero;
        if (Vector3.Distance(e.player.transform.position, transform.position) < closeDist)
            direction = -1 * transform.forward;




        else if (Vector3.Distance(e.player.transform.position, transform.position) > weaponRange)
            direction = transform.forward;


        Vector3 realDirection = new Vector3(direction.x, transform.position.y, direction.z);
        rb.AddForce(direction * moveSpeed);
    }
}
