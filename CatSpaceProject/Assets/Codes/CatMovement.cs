using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour {

    //Movment speed (can be changed in Unity GUI)
    public float speed = 1f;
    public float jetPower = 1f;
    public float throwingPower = 1f;
    public float rotateSpeed = 1f;

    public float startfuelLevel = 100;
    public float fuelLevel;

    Rigidbody catbody;
    Collider catcollider;

    GameObject[] items;
    public GameObject obj;
    Rigidbody objbody;

    Vector3 movement;

    float hmove;
    float vmove;
    //float udmove;

    bool throwObjects;
    public bool useJetpack;

    GameObject player;
    GameObject playerEquipPoint;
    public bool isPicking;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEquipPoint = GameObject.FindGameObjectWithTag("EquipPoint");
        catbody = GetComponent<Rigidbody>();
        catcollider = GetComponent<Collider>();
        items = GameObject.FindGameObjectsWithTag("Item");
        fuelLevel = startfuelLevel;
    }

    void Start()
    {

    }

    void Update()
    {
        hmove = Input.GetAxisRaw("Horizontal");
        vmove = Input.GetAxisRaw("Vertical");
        //udmove = Input.GetAxisRaw("Updown");

        if (Input.GetKey(KeyCode.LeftShift) && fuelLevel > 0 && (hmove != 0 || vmove != 0))
            useJetpack = true;
        if (isPicking == true && Input.GetKeyDown(KeyCode.Space))
            throwObjects = true;
        
        //if (Input.GetKey(KeyCode.G) && isPicking)
        //    Drop();
    }

    void FixedUpdate()
    {
        //if (emit == true)
        //    ps.Play();
        //if (emit == false)
        //    ps.Stop();

        Jetpack();
        ThrowObjects();
        Turn();

    }

    void Run()
    {
        movement.Set(hmove, 0, vmove);
        movement = movement.normalized * speed * Time.deltaTime;

        catbody.MovePosition(transform.position + movement);
    }

    void Jetpack()
    {
        if (!useJetpack)
            return;

        movement.Set(hmove, 0, vmove);
        //catbody.transform.Translate(movement.normalized * jetPower,Space.World);
        catbody.AddForce(movement.normalized * jetPower, ForceMode.Force);

        if (fuelLevel >= 0.1f)
            fuelLevel -= 0.1f;
        if (fuelLevel < 0.1f)
            fuelLevel = 0f;

        useJetpack = false;

    }

    void ThrowObjects()
    {
        if (!throwObjects)
            return;

        throwingPower = objbody.mass * 2; // F = dp/dt = d(mv)/dt
        movement.Set(hmove, 0, vmove);
        catbody.AddForce(movement.normalized * throwingPower, ForceMode.Impulse);
        objbody.AddForce((-1) * movement.normalized * throwingPower, ForceMode.Impulse);

        SetEquip(obj, false);
        playerEquipPoint.transform.DetachChildren();
        isPicking = false;

        throwObjects = false;
    }

    void Turn()
    {
        //turn only horizontal & vertical direction
        if (hmove == 0 && vmove == 0)
            return;

        Vector3 turnmove = Vector3.zero;
        turnmove.Set(hmove, 0, vmove);
        //turnmove = transform.rotation * turnmove;
        Quaternion newRotation = Quaternion.LookRotation(turnmove);
        catbody.rotation = Quaternion.Slerp(catbody.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    public void Pickup(GameObject item)
    {
        SetEquip(item, true);
        isPicking = true;

        foreach (GameObject Item in items)
        {
        if (Item.transform.IsChildOf(playerEquipPoint.transform))
            obj = Item;
        }

        objbody = obj.GetComponent<Rigidbody>();
    }

    //void Drop()
    //{
    //    GameObject item = playerEquipPoint.GetComponentInChildren<Rigidbody>().gameObject;
    //    SetEquip(item, false);
    //    playerEquipPoint.transform.DetachChildren();
    //    isPicking = false;
    //}

    void SetEquip(GameObject item, bool isEquip)
    {
        Collider[] itemColliders = item.GetComponents<Collider>();
        //Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

        foreach(Collider itemCollider in itemColliders)
        {
            itemCollider.enabled = !isEquip;
        }

        //itemRigidbody.isKinematic = isEquip;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Star")
            catbody.isKinematic = true;
            //Physics.IgnoreCollision(catcollider, collision.collider);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Star")
            catbody.isKinematic = false;
    }
}

