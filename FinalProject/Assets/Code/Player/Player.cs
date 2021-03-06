using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    int health = 5;
    public HealthManager manager;
    PauseManager pm;
    DeathManager dm;
    StartManager sm;
    private AudioSource[] sources;
    private AudioSource hitSound;
    bool dead = false;
    // if the player is the starting player i.e first player ever spawned for game run
    public bool isStartingPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        if (isStartingPlayer)
        {
            sm = GetComponent<StartManager>();
            sm.showMenu();
        }
        manager?.showHearts(health);
        pm = GetComponent<PauseManager>();
        sources = GetComponents<AudioSource>();
        hitSound = sources[1];
        dm = GetComponent<DeathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !dead)
        {
            dm?.showMenu();
            dead = true;
        }

        if (transform.position.y < 0 && !dead)
        {
            damage(health);
        }
    }

    public float getHealth()
    {
        return health;
    }

    public void addHealth(int x)
    {
        health += x;
    }

    public void damage(int x)
    {
        health -= x;
        hitSound.Play();
        manager?.showHearts(health);
        //yield return new WaitForSeconds(1);
    }

    public Vector3 getPos()
    {
        return transform.position;
    }

    public bool isDead()
    {
        return dead;
    }
}
