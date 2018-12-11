using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDeathZone : MonoBehaviour {

    DeathZoneScript deathscript;
    // Use this for initialization

    private void Awake()
    {
        deathscript = gameObject.GetComponentInParent<DeathZoneScript>();
    }

    private void OnTriggerExit(Collider other)
    {
        
        if(GameObject.Equals(other.gameObject, GameObject.Find("Cat Lite")))
        {
            Debug.Log("Exit");
            deathscript.outOfZone = true;
            //print("Object: "+other.gameObject+" is out!");
            deathscript.Call();
        }         
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (GameObject.Equals(other.gameObject, GameObject.Find("Cat Lite")))
        {
            Debug.Log("Enter");
            deathscript.outOfZone = false;
            deathscript.Call();
        }
           
    }
}
