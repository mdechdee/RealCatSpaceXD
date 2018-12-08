using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemScript : MonoBehaviour {

    GameObject player;
    GameObject playerEquipPoint;
    CatMovement playerLogic;

    Collider[] itemcolliders;

    Vector3 forceDirection;
    public bool isPlayerEnter;

    public Text ItemText;
    float flashSpeed = 5f;
    Color flashColor = Color.white;
    Transform itemtransform;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X) && isPlayerEnter)
        {
            transform.SetParent(playerEquipPoint.transform);
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);

            playerLogic.Pickup(gameObject);
            isPlayerEnter = false;
            
        }

        if (this.transform.IsChildOf(playerEquipPoint.transform))
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);

        if (playerLogic.isPicking == true)
            ItemText.color = Color.clear;

    }

    void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
            ItemText.color = flashColor;
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
