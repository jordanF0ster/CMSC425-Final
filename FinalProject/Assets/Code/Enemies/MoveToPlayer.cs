using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to have enemies chase player
// should be used for melee range enemies


public class MoveToPlayer : MonoBehaviour
{

    public float speed = 10f;
    public Player player;
    public float rotationSpeed;
    //float health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * speed * Time.deltaTime;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(dist);
        //if (dist < 1)
        //{
        //    StartCoroutine(player.damage(1));
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.name == "Player" || collision.collider.name == "Blaster")
        {
            Debug.Log("HIT");
            player.damage(1);
        }
    }
}
