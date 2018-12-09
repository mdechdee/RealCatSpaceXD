using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemScript : MonoBehaviour {

    GameObject player;
    GameObject playerEquipPoint;
    CatMovement playerLogic;

    Collider[] itemcolliders;
    Transform[] childitem;
    Vector3 forceDirection;
    public bool isPlayerEnter;

    public Text ItemText;
    float flashSpeed = 5f;
    Color flashColor = Color.white;
    Transform itemtransform;
    Color orange,nocolor;
    void Awake()
    {
        itemcolliders = GetComponentsInChildren<Collider>();
        foreach (Collider itemcollider in itemcolliders)
            itemcollider.isTrigger = true;
        player = GameObject.FindGameObjectWithTag("Player");
        playerEquipPoint = GameObject.FindGameObjectWithTag("EquipPoint");
        playerLogic = player.GetComponent<CatMovement>();

        ItemText = GameObject.Find("ItemText").GetComponent<Text>();
        itemtransform = GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {
        orange = new Color(0.9f, 0.5f, 0.1f, 1.0f);
        nocolor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }
    void turn_slot1() {
        for (int i = 1; i < 6; i++)
        {
            GameObject slots = GameObject.Find("HUDCanvas/InventoryPanel/Slot_" + i.ToString());
            slots.GetComponent<Image>().color = nocolor;
        }


        GameObject border = GameObject.Find("HUDCanvas/InventoryPanel/Slot_1");
        border.GetComponent<Image>().color = orange;

    }        
	

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X) && isPlayerEnter)
        {


            childitem = playerEquipPoint.GetComponentsInChildren<Transform>();
            int countitem=0;
            foreach (Transform item in childitem)
            {
                if (item.gameObject.tag == "Item") {
                    countitem += 1;
                }
            }
            Debug.Log(countitem);
            if (countitem < 5)
            {
                transform.SetParent(playerEquipPoint.transform);
                transform.localPosition = Vector3.zero;
                transform.rotation = new Quaternion(0, 0, 0, 0);
                this.GetComponent<Collider>().enabled = false;

                playerLogic.Pickup(gameObject);
                isPlayerEnter = false;
                GameObject panel = GameObject.Find("HUDCanvas/InventoryPanel/Slot_" + (countitem + 1).ToString()+"/Border/ItemImage");
                Debug.Log(panel.GetComponent<Text>().text);
                panel.GetComponent<Text>().text = this.GetComponent<Rigidbody>().mass.ToString()+"kg";
                if (countitem == 0) {
                    turn_slot1();
                }

            }
            else {

            }
            
            
        }

        if (this.transform.IsChildOf(playerEquipPoint.transform))
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);

        if (playerLogic.isPicking == true)
            ItemText.color = Color.clear;

    }

    void OnTriggerEnter(Collider other)
    {

        childitem = playerEquipPoint.GetComponentsInChildren<Transform>();
        int countitem = 0;
        foreach (Transform item in childitem)
        {
            if (item.gameObject.tag == "Item")
            {
                countitem += 1;
            }
        }
        if (countitem < 5)
        {
            if (other.gameObject == player)
            {
                isPlayerEnter = true;
                ItemText.color = flashColor;
            }
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
            ItemText.color = Color.clear;
        }
    }
}
