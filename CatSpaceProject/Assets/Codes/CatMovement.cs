using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour {

    //Movment speed (can be changed in Unity GUI)
    public float speed = 1f;
    public float jetPower = 1f;
    float throwingPower = 1f;
    public float rotateSpeed = 1f;

    public float startfuelLevel = 100;
    public float fuelLevel;

    Rigidbody catbody;
    ParticleSystem ps;

    GameObject item;
    Rigidbody itembody;

    Vector3 movement;

    float hmove;
    float vmove;
    //float udmove;

    bool throwObjects;
    bool useJetpack;
    bool emit = false;

    GameObject player;
    GameObject playerEquipPoint;
    public bool isPicking;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEquipPoint = GameObject.FindGameObjectWithTag("EquipPoint");

        catbody = GetComponent<Rigidbody>();
        ps = GetComponentInChildren<ParticleSystem>();
        item = GameObject.Find("Item");
        itembody = item.GetComponent<Rigidbody>();
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
       
        if (!Input.GetKey(KeyCode.LeftShift))
            emit = true;
        
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
        catbody.AddForce(movement.normalized * jetPower, ForceMode.Acceleration);

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

        throwingPower = itembody.mass;
        movement.Set(hmove, 0, vmove);
        catbody.AddForce(movement.normalized * throwingPower, ForceMode.Impulse);
        itembody.AddForce((-1) * movement.normalized * throwingPower, ForceMode.Impulse);

        SetEquip(item, false);
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
}

//jetpack: constant force, therfore constant acceleration
//If you press the key continuously, the cat experience the constant force (constant acceleration)
//if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.LeftShift))
//    catbody.AddForce(Vector3.right * jumpPower, ForceMode.Acceleration);
//if (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.LeftShift))
//    catbody.AddForce(Vector3.left * jumpPower, ForceMode.Acceleration);
//if (Input.GetKey(KeyCode.UpArrow) & Input.GetKey(KeyCode.LeftShift))
//    catbody.AddForce(Vector3.back * jumpPower, ForceMode.Acceleration);
//if (Input.GetKey(KeyCode.DownArrow) & Input.GetKey(KeyCode.LeftShift))
//    catbody.AddForce(Vector3.forward * jumpPower, ForceMode.Acceleration);
//if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.LeftShift))
//    catbody.AddForce(Vector3.up * jumpPower, ForceMode.Acceleration);
//if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.LeftShift))
//    catbody.AddForce(Vector3.down * jumpPower, ForceMode.Acceleration);

//throwing object: impulse force from action & reaction
//If you press the key once, the cat experience the impulse force.
//if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKeyDown(KeyCode.Space))
//    catbody.AddForce(Vector3.right * jumpPower, ForceMode.Impulse);
//if (Input.GetKey(KeyCode.RightArrow) & Input.GetKeyDown(KeyCode.Space))
//    catbody.AddForce(Vector3.left * jumpPower, ForceMode.Impulse);
//if (Input.GetKey(KeyCode.UpArrow) & Input.GetKeyDown(KeyCode.Space))
//    catbody.AddForce(Vector3.back * jumpPower, ForceMode.Impulse);
//if (Input.GetKey(KeyCode.DownArrow) & Input.GetKeyDown(KeyCode.Space))
//    catbody.AddForce(Vector3.forward * jumpPower, ForceMode.Impulse);
//if (Input.GetKey(KeyCode.W) & Input.GetKeyDown(KeyCode.Space))
//    catbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
//if (Input.GetKey(KeyCode.S) & Input.GetKeyDown(KeyCode.Space))
//    catbody.AddForce(Vector3.down * jumpPower, ForceMode.Impulse);
