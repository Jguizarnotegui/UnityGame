using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    GameObject player;
    PlayerCharacter playerHealth;
    Animator anim;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerCharacter>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth._health <= 0)
        {
            anim.SetBool("GameOver", true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("GameOver", false);
        }

    }
}
