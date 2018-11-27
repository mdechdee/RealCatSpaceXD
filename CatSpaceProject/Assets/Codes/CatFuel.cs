using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatFuel : MonoBehaviour
{
    //public float startingFuel;                            // The amount of health the player starts the game with.
    public float currentFuel;                                   // The current health the player has.
    public Slider FuelSlider;                                 // Reference to the UI's health bar.
    public Text NoFuelText;                                   // Reference to an image to flash on the screen on being hurt.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColor = Color.red;     // The colour the damageImage is set to, to flash.


    //Animator anim;                                              // Reference to the Animator component.
    //AudioSource playerAudio;                                    // Reference to the AudioSource component.
    CatMovement catMovement;                              // Reference to the player's movement.
    //PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
    //bool isExhausted;                                                // Whether the player is dead.
    //bool used;                                               // True when the player gets damaged.
    GameObject HUD;

    void Awake()
    {
        // Setting up the references.
        //anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
        HUD = GameObject.FindGameObjectWithTag("HUD");
        catMovement = GetComponent<CatMovement>();
        FuelSlider = HUD.GetComponentInChildren<Slider>();
        NoFuelText = HUD.GetComponentInChildren<Text>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();

        // Set the initial health of the player.
        //startingFuel = catMovement.startfuelLevel;
        FuelSlider.maxValue = catMovement.startfuelLevel;
        currentFuel = catMovement.startfuelLevel;
    }


    void Update()
    {
        currentFuel = catMovement.fuelLevel;
        // If the player has just been damaged...
        if (currentFuel <= 0)
        {
            // ... set the colour of the damageImage to the flash colour.
            NoFuelText.color = flashColor;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            NoFuelText.color = Color.Lerp(NoFuelText.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        FuelSlider.value = currentFuel;

        // Reset the damaged flag.
        //damaged = false;
    }

}