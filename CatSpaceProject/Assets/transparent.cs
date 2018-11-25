using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transparent : MonoBehaviour {
    RawImage m_Image;

	// Use this for initialization
	void Start () {
        m_Image = GetComponent<RawImage>();

	}
	
	// Update is called once per frame
	void Update () {
        float alpha = 0.5f; //1 is opaque, 0 is transparent
        Color currColor = m_Image.color;
        currColor.a = alpha;
        m_Image.color = currColor;
	}
}
