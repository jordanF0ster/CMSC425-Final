using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{

    public Transform tip;
    public float shootDist = 10;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(shoot());

            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;

            line.SetPosition(0, tip.position);

            if (Physics.Raycast(transform.position, fwd, out hit, shootDist))
                line.SetPosition(1, hit.point);
            else
            {
                line.SetPosition(1, transform.position + (fwd * shootDist));
                Debug.Log("THIS DIST: " + (transform.position + (fwd * shootDist)));
            }
        }
    }

    public IEnumerator shoot()
    {
        line.enabled = true;
        yield return new WaitForSeconds(0.5f);
        line.enabled = false;
    }
}
