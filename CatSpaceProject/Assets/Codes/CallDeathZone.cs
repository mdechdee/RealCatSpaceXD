using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDeathZone : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider collider)
    {
        print(1);
        gameObject.GetComponentInParent<DeathZoneScript>().Call();
        
    }
}
