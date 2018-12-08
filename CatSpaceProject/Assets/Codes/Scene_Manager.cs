using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour {

    public static bool gameEnd;

    void Awake()
    {
        gameEnd = false;
    }

    void Update()
    {
        if (gameEnd && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("PhysicsScene");
        }    
    }

}
