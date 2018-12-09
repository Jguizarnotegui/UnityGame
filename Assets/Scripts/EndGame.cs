using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
    GameObject player;
    PlayerCharacter playerHealth;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerCharacter>();
        
    }
	
	// Update is called once per frame
	void Update () {

		if (playerHealth._health == 0)
        {
            SceneManager.LoadScene("EndScene");
            Cursor.lockState = CursorLockMode.None;
            //Set Cursor to not be visible
            Cursor.visible = true;
        }
	}
}
