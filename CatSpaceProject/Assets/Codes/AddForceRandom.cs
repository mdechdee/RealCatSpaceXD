using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody[] allObjects = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
        foreach(Rigidbody obj in allObjects)
        {
            obj.AddTorque(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
