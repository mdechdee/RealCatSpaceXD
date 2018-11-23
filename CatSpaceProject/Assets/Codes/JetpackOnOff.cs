using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackOnOff : MonoBehaviour {

    // Use this for initialization
    ParticleSystem jetpackPs;
	void Start () {
        jetpackPs = this.GetComponent<ParticleSystem>();
        if(jetpackPs == null)
        {
            print("No Jetpack Flame!");
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift)==true)
        {
            if(jetpackPs.isPlaying == false)
                jetpackPs.Play();
        }
        else
        {
            jetpackPs.Stop();
        }
	}
}
