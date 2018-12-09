using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDeathZone : MonoBehaviour {

    // Use this for initialization

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<CatMovement>().fuelLevel > 0 && GameObject.Equals(other.gameObject, GameObject.Find("Cat Lite")))
        {
            print("Object: "+other.gameObject+" is out!");
            gameObject.GetComponentInParent<DeathZoneScript>().Call();
        }
            
        
    }

}
