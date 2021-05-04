using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    int health = 5;
    public HealthManager manager;
    PauseManager pm;
    DeathManager dm;
    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        manager?.showHearts(health);
        pm = GetComponent<PauseManager>();
        dm = GetComponent<DeathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !dead)
        {
            dm?.showMenu();
            dead = true;

//            Debug.Log("YOU ARE DEAD");
//#if UNITY_EDITOR
//#else
//            Application.Quit();
//#endif
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
        Debug.Log("DAMAGE");
        health -= x;

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
