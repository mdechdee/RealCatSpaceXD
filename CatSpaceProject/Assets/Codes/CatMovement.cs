using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatMovement : MonoBehaviour {

    //Movment speed (can be changed in Unity GUI)
    public float speed = 1f;
    public float jetPower = 1f;
    public float throwingPower = 1f;
    public float rotateSpeed = 1f;

    public float startfuelLevel = 100;
    public float fuelLevel;
<<<<<<< HEAD
    Color orange;
    Color nocolor;

    GameObject itemparent;
    int throw_inven;
=======
    public float maxSpeed = 10;
>>>>>>> 509963802c057396d95687b8ef41c439cdd4bfe3
    Rigidbody catbody;
    Collider catcollider;
    GameObject[] items;
    GameObject[] throw_items;
    public GameObject obj;
    Rigidbody objbody;

    Vector3 movement;

    float hmove;
    float vmove;
    //float udmove;

    bool throwObjects;
    public bool useJetpack;
    Transform[] childitem;
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
        itemparent = GameObject.Find("Item");
        throw_items = new GameObject[5];
        throw_inven = 1;
        orange = new Color(0.9f, 0.5f, 0.1f, 1.0f);
        nocolor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        for (int i = 1; i < 6; i++)
        {
            GameObject slots = GameObject.Find("HUDCanvas/InventoryPanel/Slot_" + i.ToString());
            slots.GetComponent<Image>().color = nocolor;
        }


    }

    void Update()
    {
        hmove = Input.GetAxisRaw("Horizontal");
        vmove = Input.GetAxisRaw("Vertical");
        //udmove = Input.GetAxisRaw("Updown");

        if (Input.GetKey(KeyCode.LeftShift) && fuelLevel > 0 && (hmove != 0 || vmove != 0))
            useJetpack = true;
        if (Input.GetKeyDown(KeyCode.C))
            throwObjects = true;
        if (Input.GetKeyDown(KeyCode.I)) {

            GameObject oldborder = GameObject.Find("HUDCanvas/InventoryPanel/Slot_" + throw_inven.ToString());
            oldborder.GetComponent<Image>().color = nocolor;
            throw_inven =(throw_inven+1)%5;
            if (throw_inven == 0)
                throw_inven = 5;
            GameObject border = GameObject.Find("HUDCanvas/InventoryPanel/Slot_"+throw_inven.ToString());
            border.GetComponent<Image>().color = orange;
        }

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
        if(catbody.velocity.magnitude>maxSpeed)
        {
            catbody.velocity= catbody.velocity.normalized* maxSpeed;
        }
        if (fuelLevel >= 0.1f)
            fuelLevel -= 0.1f;
        if (fuelLevel < 0.1f)
            fuelLevel = 0f;

        useJetpack = false;

    }
    void adjustText() {
        int numitem = 0;


        throw_items = new GameObject[5];
        childitem = playerEquipPoint.GetComponentsInChildren<Transform>();
        for (int i =1; i < 6; i++) {
            GameObject panel = GameObject.Find("HUDCanvas/InventoryPanel/Slot_" + i.ToString() + "/Border/ItemImage");
            panel.GetComponent<Text>().text = "";
        }
        int countitem = 0;
        foreach (Transform item in childitem)
        {
            if (item.gameObject.tag == "Item")
            {
                throw_items[countitem] = item.gameObject;
                GameObject panel = GameObject.Find("HUDCanvas/InventoryPanel/Slot_" + (countitem + 1).ToString() + "/Border/ItemImage");
                Debug.Log(panel.GetComponent<Text>().text);
                panel.GetComponent<Text>().text = item.gameObject.GetComponent<Rigidbody>().mass.ToString() + "kg";
                countitem++;
            }

        }
        foreach (Transform item in childitem)
        {
            if (item.gameObject.tag == "Item")
            {
                numitem += 1;
            }

        }
        for (int i = 1; i < 6; i++)
        {
            GameObject slots = GameObject.Find("HUDCanvas/InventoryPanel/Slot_" + i.ToString());
            slots.GetComponent<Image>().color = nocolor;
        }

        if (numitem > 0)
        {
            GameObject border = GameObject.Find("HUDCanvas/InventoryPanel/Slot_1");
            border.GetComponent<Image>().color = orange;
            throw_inven = 1;
        }


    }

    void ThrowObjects()
    {
        if (!throwObjects)
            return;

        childitem = playerEquipPoint.GetComponentsInChildren<Transform>();
        int countitem = 0;
        foreach (Transform item in childitem)
        {
            if (item.gameObject.tag=="Item") {
                throw_items[countitem] = item.gameObject;
                countitem++;
            }

        }
        objbody = throw_items[throw_inven-1].GetComponent<Rigidbody>();

        throwingPower = objbody.mass * 2; // F = dp/dt = d(mv)/dt
        movement.Set(hmove, 0, vmove);
        catbody.AddForce(movement.normalized * throwingPower, ForceMode.Impulse);
        objbody.AddForce((-1) * movement.normalized * throwingPower, ForceMode.Impulse);

        SetEquip(obj, false);
        throw_items[throw_inven - 1].GetComponent<Collider>().enabled = true;
        throw_items[throw_inven - 1].transform.SetParent(itemparent.transform);
      
        adjustText();
        isPicking = false;

        throwObjects = false;
    }

    void Turn()
    {
        //turn only horizontal & vertical direction
        if (hmove == 0 && vmove == 0)
            return;

        Vector3 turnmove = Vector3.zero;
        //Vector3 torquemove;
        turnmove.Set(hmove, 0, vmove);
        //torquemove.Set()
        //turnmove = transform.rotation * turnmove;
        Quaternion newRotation = Quaternion.LookRotation(turnmove);
        catbody.rotation = Quaternion.Slerp(catbody.rotation, newRotation, rotateSpeed * Time.deltaTime);
        //catbody.Add (turnmove);
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
        if (collision.gameObject.name == "EARTH")
            EndGame();
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Star")
            catbody.isKinematic = false;
    }

    void EndGame()
    {
        Scene_Manager.gameEnd = true;
    }
}

