using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public bool hooked;
    public GameObject hookedObj;

    public float maxDistance;
    private float currentDistance;

    private bool grounded;

    private void Awake()
    {
        hook = GameObject.Find("Hook");
        hookHolder = GameObject.Find("Hook Holder");
    }

    private void Update()
    {
        // firing the hook
        if (Input.GetMouseButtonDown(0) && fired == false)
            fired = true;

        if (fired == true)
        {
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetVertexCount(2);
            rope.SetPosition(0, hookHolder.transform.position);
            rope.SetPosition(1, hook.transform.position);
        }

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
                ReturnHook();
        }

        if (hooked == true && fired == true)
        {
            hook.transform.parent = hookedObj.transform;

            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            //this.GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook < 1)
            {
                if (grounded == false)
                {
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 13f);
                    //this.transform.Translate(Vector3.up * Time.deltaTime * 18f);
                }

                StartCoroutine("Climb");
            }

        }

        else
        {
            hook.transform.parent = hookHolder.transform;
            //this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    IEnumerator Climb()
    {
        yield return new WaitForSeconds(0.1f);
        ReturnHook();
    }

    void ReturnHook()
    {
        hook.transform.rotation = hookHolder.transform.rotation;
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;

        LineRenderer rope = hook.GetComponent<LineRenderer>();
        rope.SetVertexCount(0);
    }

    void CheckIfGrounded()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

}