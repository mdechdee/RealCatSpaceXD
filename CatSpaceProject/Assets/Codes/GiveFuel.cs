using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFuel : MonoBehaviour {

    Collider coll;
    public AudioSource GetFuelSound;

    private void Awake()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        GetFuelSound = GetComponent<AudioSource>();
        GetFuelSound.time = 0.5f;
    }

    [SerializeField] float containFuel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cat Lite")
        {
            GetFuelSound.Play();
            CatMovement a = other.gameObject.GetComponent<CatMovement>();
            a.fuelLevel += containFuel;
            if (a.fuelLevel > a.startfuelLevel)
                a.fuelLevel = a.startfuelLevel;
            StartCoroutine(Wait());
            Destroy(gameObject);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f);
    }
}
