﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float shootTime = 7f;
    float shootDist = 20;
    private LineRenderer line;
    bool isShooting = false;
    Enemy e;
    PauseManager pm;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        e = GetComponent<Enemy>();
        pm = e.player.GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShooting && !pm.isPaused())
            StartCoroutine(shoot());
    }

    public float getRange()
    {
        return shootDist;
    }


    // method to periodically shoot every shootTime seconds
    // first a line is rendered to act as a targeting system,
    // then the line changes color to signify it shooting.
    public IEnumerator shoot()
    {
        line.enabled = true;
        if (isShooting)
            yield break;

        isShooting = true;


        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        line.SetPosition(0, transform.position);


        if (Physics.Raycast(transform.position, fwd, out hit, shootDist))
        {
            Player player = hit.collider.GetComponent<Player>();
            line.SetPosition(1, hit.point);
            if (player != null && !pm.isPaused())
            {
                player.damage(1);
            }
        }
        else
        {
            line.SetPosition(1, transform.position + (fwd * shootDist));
        }

        yield return new WaitForSeconds(0.5f);
        line.enabled = false;

        yield return new WaitForSeconds(shootTime);
        isShooting = false;
    }
}
