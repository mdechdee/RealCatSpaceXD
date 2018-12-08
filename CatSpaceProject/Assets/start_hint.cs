using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start_hint : MonoBehaviour {

    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        this.GetComponent<RawImage>().enabled = false;
    }


	// Use this for initialization
	void Start () {
       this.GetComponent<RawImage>().enabled = true;
        StartCoroutine(Example());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
