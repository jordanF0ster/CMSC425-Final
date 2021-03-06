using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to have enemies chase player
// should be used for melee range enemies


public class MoveToPlayer : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed;
    Enemy e;
    PauseManager pm;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        e = this.GetComponent<Enemy>();
        pm = e.player.GetComponent<PauseManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (e != null && e.player != null && !pm.isPaused())
        {
            transform.LookAt(e.player.getPos());
            //transform.position += transform.forward * speed * Time.deltaTime;
            rb.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
        }
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
