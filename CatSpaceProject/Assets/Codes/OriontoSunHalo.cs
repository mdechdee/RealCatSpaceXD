using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriontoSunHalo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onTriggerEnter(Collider other)
    {
        Light halo1 = GameObject.Find("Asteroids/OriontoSun/Asteroid01").GetComponent<Light>();
        Light halo2 = GameObject.Find("Asteroids/OriontoSun/Asteroid02").GetComponent<Light>();
        Light halo3 = GameObject.Find("Asteroids/OriontoSun/Asteroid08").GetComponent<Light>();
        Light halo4 = GameObject.Find("Asteroids/OriontoSun/Asteroid09").GetComponent<Light>();
        Light halo5 = GameObject.Find("Asteroids/OriontoSun/Asteroid010").GetComponent<Light>();
        Light halo6 = GameObject.Find("Asteroids/OriontoSun/Asteroid011").GetComponent<Light>();

        if (other.gameObject.name == "Cat Lite")
            halo1.enabled = true;
            halo2.enabled = true;
            halo3.enabled = true;
            halo4.enabled = true;
            halo5.enabled = true;
            halo6.enabled = true;
    }
}
