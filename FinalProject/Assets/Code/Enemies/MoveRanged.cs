using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRanged : MonoBehaviour
{
    public Player player;
    Vector3 dist;
    float speed = 10;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dist = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void maintainDist()
    {
        rb.MovePosition(player.transform.position + (dist * speed * Time.deltaTime));
        //transform.position = Vector3.Lerp(transform.position, player.transform.position + dist, speed * Time.deltaTime);
        transform.LookAt(player.transform);
    }

}
