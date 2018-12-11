using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hint : MonoBehaviour {
    public string hint_name;
    public string turnon;
    GameObject hint_obj;
    GameObject turn_on;
    float hint_time;
    bool count;
	// Use this for initialization
    Transform[] children;

    void Start () {
        hint_obj = GameObject.Find("HUDCanvas/" + hint_name);
        hint_time = -1.0f;
        turn_on = GameObject.Find(turnon);

	}
	void OnTriggerEnter (Collider col)
    {

        if(col.gameObject.name == "Cat Lite")
        {
            hint_obj.GetComponent<RawImage>().enabled = true;
            //this.GetComponent<BoxCollider>().enabled = false;
            hint_time = 0.0f;
            if (this.name != "FalseOrion") {
                if (turnon == "Orion")
                {
                    turn_on.GetComponent<BoxCollider>().enabled = true;
                    int child_count = turn_on.transform.childCount;
                    for (int i = 0; i < child_count; i++)
                    {
                        Transform child = turn_on.gameObject.transform.GetChild(i);
                        child.GetComponent<SphereCollider>().enabled = true;
                        child.GetComponent<MeshRenderer>().enabled = true;
                        child.GetComponent<Light>().enabled = true;
                        (child.GetComponent("Halo") as Behaviour).enabled = true;
                    }
                    GameObject bigtoorion = GameObject.Find("BigDippertoOrion");
                    int asteroid_count = bigtoorion.transform.childCount;
                    for (int i = 0; i < asteroid_count; i++)
                    {
                        Transform child = bigtoorion.gameObject.transform.GetChild(i);

                        (child.GetComponent("Halo") as Behaviour).enabled = true;
                    }

                }
                else if (turnon == "Sun" || turnon == "EARTH")
                {
                    if (turnon == "Sun")
                    {
                        GameObject oriontosun = GameObject.Find("OriontoSun");
                        int asteroid_count = oriontosun.transform.childCount;
                        for (int i = 0; i < asteroid_count; i++)
                        {

                            Transform child = oriontosun.gameObject.transform.GetChild(i);
                            if(child.gameObject.tag=="orion")
                                (child.GetComponent("Halo") as Behaviour).enabled = true;
                       

                        }
                        GameObject bigtoorion = GameObject.Find("BigDippertoOrion");
                        asteroid_count = bigtoorion.transform.childCount;
                        for (int i = 0; i < asteroid_count; i++)
                        {
                            Transform child = bigtoorion.gameObject.transform.GetChild(i);

                            (child.GetComponent("Halo") as Behaviour).enabled = false;
                        }
                    }
                    else {
                        GameObject oriontosun = GameObject.Find("OriontoSun");
                        int asteroid_count = oriontosun.transform.childCount;
                        for (int i = 0; i < asteroid_count; i++)
                        {
                            if (oriontosun.tag == "orion")
                            {
                                Transform child = oriontosun.gameObject.transform.GetChild(i);

                                (child.GetComponent("Halo") as Behaviour).enabled = false;
                            }

                        }

                    }
                    turn_on.GetComponent<MeshRenderer>().enabled = true;
                    turn_on.GetComponent<SphereCollider>().enabled = true;
                    turn_on.GetComponent<Light>().enabled = true;
                }


            }
            }
            
    }


	// Update is called once per frame
	void Update () {
        if (hint_time >= 0.0f) {
            hint_time += Time.deltaTime;
        }
        if (hint_time > 10.0f) {
            hint_obj.GetComponent<RawImage>().enabled = false;
            hint_time = -1.0f;
        }
	}
}
