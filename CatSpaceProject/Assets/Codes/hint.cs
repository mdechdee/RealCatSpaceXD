using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hint : MonoBehaviour {
    public string hint_name;
    GameObject hint_obj;
    float hint_time;
    bool count;
	// Use this for initialization

    void Start () {
        hint_obj = GameObject.Find("HUDCanvas/" + hint_name);
        hint_time = -1.0f;

	}
	void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "Cat Lite")
        {
            hint_obj.GetComponent<RawImage>().enabled = true;
            //this.GetComponent<BoxCollider>().enabled = false;
            hint_time = 0.0f;   
        }
    }


	// Update is called once per frame
	void Update () {
        if (hint_time >= 0.0f) {
            hint_time += Time.deltaTime;
        }
        if (hint_time > 5.0f) {
            hint_obj.GetComponent<RawImage>().enabled = false;
            hint_time = -1.0f;
        }
	}
}
