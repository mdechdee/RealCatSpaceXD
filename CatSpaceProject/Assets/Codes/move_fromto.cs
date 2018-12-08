﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_fromto : MonoBehaviour {
    Vector3 from_pos, to_pos, ast_pos;
    public float factor, offset_x, offset_y, offset_z;
    public string from, to;
    public float add;
    float new_add;
	// Use this for initialization
	void Start () {
        from_pos = GameObject.Find(from).transform.position;
        to_pos = GameObject.Find(to).transform.position;
        transform.position = to_pos;
        Debug.Log(from_pos.x);

        new_add = add;
	}
	
	// Update is called once per frame
	void Update () {
        
        ast_pos = from_pos * factor + to_pos * (1 - factor);
        if (factor > 1.0f)
            new_add = -add;
        else if (factor < 0.0f)
            new_add = add;
        factor += new_add;
        Vector3 offset = new Vector3(offset_x, offset_y, offset_z);
        transform.position = ast_pos + offset;
	}
}
