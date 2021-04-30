using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to have enemies chase player
// should be used for melee range enemies


public class MoveToPlayer : MonoBehaviour
{

    public float speed = 5f;
    //Player player;
    public float rotationSpeed;
    Enemy e;
    //float health = 5;

    // Start is called before the first frame update
    void Start()
    {
        e = this.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (e != null && e.player != null)
        {
            transform.LookAt(e.player.getPos());
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        //float dist = Vector3.Distance(e.player.transform.position, transform.position);
        //Debug.Log(dist);
        //if (dist < 1)
        //{
        //    StartCoroutine(player.damage(1));
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name == "Player" || collision.collider.name == "Blaster")
        {
            Debug.Log("HIT");
            e.player.damage(1);
        }
    }
}
