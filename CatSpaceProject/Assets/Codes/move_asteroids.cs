using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_asteroids: MonoBehaviour
{
    public float factor;
    public string position0, position1;
    public float step_speed;
    string destination;
    GameObject to;
    Vector3 to_vector;
    Vector3 ast_pos;
    // Use this for initialization
    void Start()
    {
        destination = position0;
        this.transform.position = factor * GameObject.Find(position0).transform.position + (1 - factor) * GameObject.Find(position1).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        to = GameObject.Find(destination);
        to_vector = (to.transform.position - this.transform.position) / Vector3.Distance(to.transform.position, this.transform.position);
        this.transform.position = this.transform.position + to_vector* step_speed;
        float x = this.transform.position.x;
        float z= this.transform.position.z;
        ast_pos.Set(x, 0.0f, z);
        this.transform.position = ast_pos;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == position0)
        {
            destination = position1;
        }
        else if (col.gameObject.name == position1) {
            destination = position0;
        }
    }
}

