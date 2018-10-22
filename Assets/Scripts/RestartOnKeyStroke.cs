using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Restarts the game when R key is pressed
public class RestartOnKeyStroke : MonoBehaviour {
    Vector3 defaultPosition;
    Quaternion defaultRotation;
    Vector3 defaultScale;
    int defaultHealth = 5;

    GameObject player;
    PlayerCharacter restartHealth;
    RayShooter playerShooting;
    FPSInput playerMoving;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        restartHealth = player.GetComponent<PlayerCharacter>();
        defaultPosition = restartHealth.transform.position;
        defaultRotation = restartHealth.transform.rotation;
        defaultScale = restartHealth.transform.localScale;
        playerMoving = GetComponent<FPSInput>();
        playerShooting = GetComponentInChildren<RayShooter>();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restart Worked!");
            //Application.LoadLevel(Application.loadedLevel);
            restartHealth.transform.position = defaultPosition;
            restartHealth.transform.rotation = defaultRotation;
            restartHealth.transform.localScale = defaultScale;
            restartHealth._health = defaultHealth;
            restartHealth.isDead = false;
            playerShooting.enabled = true;
            playerMoving.enabled = true;
        }
	}
}