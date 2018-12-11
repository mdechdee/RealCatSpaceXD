using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDeathZoneforCube : MonoBehaviour
{

    GrapplingHook hook;
    CatMovement catmovement;

    private void Awake()
    {
        hook = GameObject.FindGameObjectWithTag("Player").GetComponent<GrapplingHook>();
        catmovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CatMovement>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (GameObject.Equals(other.gameObject, GameObject.Find("Cat Lite")))
        {
            catmovement.gameover = true;
            GrapplingHook hook = GameObject.FindGameObjectWithTag("Player").GetComponent<GrapplingHook>();
            if (hook.hooked == true)
                hook.ReturnHook();
        }
    }
}
