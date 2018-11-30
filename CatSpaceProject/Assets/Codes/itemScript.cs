using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour {

    GameObject player;
    GameObject playerEquipPoint;
    CatMovement playerLogic;

    Collider[] itemcolliders;

    Vector3 forceDirection;
    bool isPlayerEnter;

    void Awake()
    {
        itemcolliders = GetComponentsInChildren<Collider>();
        foreach (Collider itemcollider in itemcolliders)
            itemcollider.isTrigger = true;
        player = GameObject.FindGameObjectWithTag("Player");
        playerEquipPoint = GameObject.FindGameObjectWithTag("EquipPoint");
        playerLogic = player.GetComponent<CatMovement>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F) && isPlayerEnter)
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }
}
