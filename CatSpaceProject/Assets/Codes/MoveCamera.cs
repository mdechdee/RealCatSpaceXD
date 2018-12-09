using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject catGameobject;
    public GameObject sunGameobject;
    private Vector3 iniOffset;
    private Vector3 iniCatpos;
    private float moveOffset;
    private float rotateOffset;
    private Vector3 inicamRotation;
    public float camMoveSpeed;
    public float camRotateSpeed;
    public float maxMoveDist;
    public float maxRotateAngle;
    // Use this for initialization
    void Start () {
        catGameobject = GameObject.Find("Cat Lite");
        iniOffset = this.transform.position - catGameobject.transform.position;
        inicamRotation = this.transform.eulerAngles;
        camMoveSpeed = 0.1f;
        camRotateSpeed = 0.1f;
        maxMoveDist = 10;
        maxRotateAngle = 5;
    }
    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        //adjustZoffset(vInput);
        //adjustZrotation(vInput);
    }
    // Update is called once per frame
    void LateUpdate() {
        //print(sp.transform.position);
        float vInput = Input.GetAxis("Vertical");
        transform.position = catGameobject.transform.position + iniOffset + new Vector3(0,0,-moveOffset);
        //print(inicamRotation);
        transform.eulerAngles = inicamRotation + new Vector3(rotateOffset, 0, 0);
        //transform.rotation.SetLookRotation(sunGameobject.transform.position);
        //float iniCurrYrot = transform.rotation.eulerAngles.y;
        //transform.LookAt(sunGameobject.transform.position);
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, iniCurrYrot, transform.eulerAngles.z);
    }

    private void adjustZrotation(float vInput)
    {
        if (vInput < 0)
        {
            if (rotateOffset < maxRotateAngle)
            {
                rotateOffset += camRotateSpeed;
            }
            else
                rotateOffset = maxRotateAngle;
        }
        else if (vInput>0)
        {
            if (rotateOffset > 0)
            {
                rotateOffset -= camRotateSpeed;
            }
            if (rotateOffset < 0)
                rotateOffset = 0;
        }

    }

    private void adjustZoffset(float vInput)
    {
        if (vInput < 0)
        {
            if (moveOffset < maxMoveDist)
            {
                moveOffset += camMoveSpeed;
            }
            else
                moveOffset = maxMoveDist;
        }
        else if (vInput > 0)
        {
            if (moveOffset > 0)
            {
                moveOffset -= camMoveSpeed;
            }
            if (moveOffset < 0)
                moveOffset = 0;

        }
    }

    
}
