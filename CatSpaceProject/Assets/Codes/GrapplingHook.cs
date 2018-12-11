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

    CatMovement catMovement;

    private bool grounded;

    AudioSource hookingSound;

    private void Awake()
    {
        hook = GameObject.Find("Hook");
        hookHolder = GameObject.Find("Hook Holder");
        catMovement = GetComponent<CatMovement>();
        hookingSound = hook.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Detach the hook
        if (Input.GetKeyUp(KeyCode.Space) && hooked == true)
        {
            ReturnHook();
        }

        // firing the hook
        if (Input.GetKeyDown(KeyCode.Space) && fired == false)
        {
            fired = true;
            hookingSound.Play();
        }

        if (fired == true)
        {           
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetVertexCount(2);
            rope.SetPosition(0, hookHolder.transform.position);
            rope.SetPosition(1, hook.transform.position);

            //catMovement.rotateSpeed = 0f;
        }

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
                ReturnHook();
            
        }

        if (fired == true && hooked == true && Input.GetKey(KeyCode.Space))
        {
            hook.transform.parent = hookedObj.transform;

            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            //this.GetComponent<Rigidbody>().useGravity = false;

            //if (distanceToHook < 3)
            //{
                //if (grounded == false)
                //{
                    //this.transform.Translate(Vector3.forward * Time.deltaTime * 13f);
                    //this.transform.Translate(Vector3.up * Time.deltaTime * 18f);
                //}

                //StartCoroutine("Climb");
            //}
            

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

        catMovement.rotateSpeed = 3f;
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