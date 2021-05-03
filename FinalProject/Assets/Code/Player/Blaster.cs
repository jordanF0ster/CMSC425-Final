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
            source.Play();
        }
    }

    // coroutine to show line renderer
    public IEnumerator shoot()
    {
        line.enabled = true;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        line.SetPosition(0, tip.position);


        if (Physics.Raycast(transform.position, fwd, out hit, shootDist))
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
            line.SetPosition(1, transform.position + (fwd * shootDist));
        }

        yield return new WaitForSeconds(0.5f);
        line.enabled = false;
    }
}
