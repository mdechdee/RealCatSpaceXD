using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFuel : MonoBehaviour {

    [SerializeField] float containFuel;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Cat Lite")
        {
            CatMovement a = collision.gameObject.GetComponent<CatMovement>();
            a.fuelLevel += containFuel;
            if (a.fuelLevel > a.startfuelLevel)
                a.fuelLevel = a.startfuelLevel;
            Destroy(gameObject);
        }
    }
}
