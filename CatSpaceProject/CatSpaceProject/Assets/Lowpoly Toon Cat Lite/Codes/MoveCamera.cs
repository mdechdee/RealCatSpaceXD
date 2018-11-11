using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject sp ;
	// Use this for initialization
	void Start () {
        sp = GameObject.Find("Cat Lite");
        transform.position = sp.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(sp)
        {
            //print(sp.transform.position);
            transform.position = sp.transform.position + new Vector3(0,5,-9);
        }
    }
}
