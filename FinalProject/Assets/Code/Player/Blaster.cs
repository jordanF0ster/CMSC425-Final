using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{

    public Transform tip;
    public float shootDist = 20;
    private LineRenderer line;
    private AudioSource source;
    PauseManager pm;
    bool isShooting = false;


    void Start()
    {
        line = GetComponent<LineRenderer>();
        source = GetComponent<AudioSource>();
        pm = GameObject.FindGameObjectWithTag("PlayerGo").GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !pm.isPaused())
        {
            StartCoroutine(shoot());
        }
    }

    // coroutine to show line renderer
    public IEnumerator shoot()
    {
        if (isShooting)
            yield break;

        isShooting = true;
        line.enabled = true;

        // we use the player transform instead of blaster because of the blaster's offset from the center
        // the player's forward vector is where they are actually looking, not the blaster's transform
        Vector3 shootDirection = transform.parent.forward;

        RaycastHit hit;



        line.SetPosition(0, tip.position);
        source.Play();

        if (Physics.Raycast(transform.position, shootDirection, out hit, shootDist))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();

            line.SetPosition(1, hit.point);
            if (enemy != null && !pm.isPaused())
            {
                enemy.mark();
            }
        }
        else
        {
            line.SetPosition(1, transform.position + (shootDirection * shootDist));
        }

        yield return new WaitForSeconds(0.5f);
        line.enabled = false;
        isShooting = false;
    }
}
