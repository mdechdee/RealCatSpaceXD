using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject catGameobject;
    private Vector3 offset;
    private Transform inicamPosition;
    // Use this for initialization
    void Start () {
        catGameobject = GameObject.Find("Cat Lite");
        offset = this.transform.position - catGameobject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() {
        //print(sp.transform.position);
        transform.position = catGameobject.transform.position + offset;
    }
    
}
