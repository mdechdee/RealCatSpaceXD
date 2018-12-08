using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFuel : MonoBehaviour {

    Collider coll;

    private void Awake()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }

    [SerializeField] float containFuel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cat Lite")
        {
            CatMovement a = other.gameObject.GetComponent<CatMovement>();
            a.fuelLevel += containFuel;
            if (a.fuelLevel > a.startfuelLevel)
                a.fuelLevel = a.startfuelLevel;
            Destroy(gameObject);
        }
    }
}
