using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDeathZoneforCube : MonoBehaviour
{

    // Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.Equals(other.gameObject, GameObject.Find("Cat Lite")))
        {
            GameObject.Find("DeathZone").GetComponent<DeathZoneScript>().Call();
            GrapplingHook hook = GameObject.FindGameObjectWithTag("Player").GetComponent<GrapplingHook>();
            hook.ReturnHook();
        }
    }
}
