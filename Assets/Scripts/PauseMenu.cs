using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gamePaused = false;
    public GameObject PauseMenuUI;
    PlayerCharacter player;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Set Cursor to not be visible
        Cursor.visible = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        //Set Cursor to not be visible
        Cursor.visible = true;
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        Time.timeScale = 1f;
        gamePaused = false;
        SceneManager.LoadScene("Menu");
    }
    public void SaveGame()
    {
        SaveSystem.SavePlayer(player);//check if it works
}
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
