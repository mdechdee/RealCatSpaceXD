using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour {

    // Use this for initialization
    Rigidbody catBody;
    Rigidbody planetBody;
    public float pullDist;
    public const float GRAVITY_CONSTANT = 75;
	void Start () {
        catBody = GameObject.Find("Cat Lite").GetComponent<Rigidbody>();
        planetBody = this.GetComponent<Rigidbody>();
        pullDist = 60;
    }
	
	// Update is called once per frame
	void Update () {
        if (!this.GetComponent<Rigidbody>())
            return;
        Vector3 catDist = this.transform.position - catBody.transform.position;
        float dis = Vector3.Magnitude(catDist);
        float gravityForce = GRAVITY_CONSTANT * catBody.mass * planetBody.mass / (dis * dis);
        catDist.y = 0f;
        if (dis < pullDist)
        {
            //print(catBody.mass * planetBody.mass / (dis * dis));
            //print(catDist.normalized * (catBody.mass * planetBody.mass / (dis * dis)));
            catBody.AddForce(catDist.normalized* gravityForce, ForceMode.Force);
        }
	}
}
