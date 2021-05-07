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
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(new Vector3(0, 1, 0), transform.position);
        float d;
        if (playerPlane.Raycast(ray, out d)) {
            fwd = ray.GetPoint(d);
        }
        Ray playerClick = new Ray(transform.position, fwd - transform.position);

        line.SetPosition(0, tip.position);
        source.Play();

        if (Physics.Raycast(playerClick, out hit, shootDist))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            //Debug.Log("EE " + enemy);
            //enemy.mark();
            //BossEnemy boss;

            //if (enemy == null)
            //{
            //    boss = hit.collider.GetComponent<BossEnemy>();
            //}

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
        isShooting = false;
    }
}
