using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI, PauseButton;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        //PauseUI.SetActive(false);
        OnUnPause();
	}
	
	// Update is called once per frame
	void Update () {
        //if escape button is pushed. Game will pause
		if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        //pauses game 
        if(paused)
        {
            PauseUI.SetActive(true);
            PauseButton.SetActive(false);
            Time.timeScale = 0;
        }
        //unpauses game
        if(!paused)
        {
            PauseUI.SetActive(false);
            PauseButton.SetActive(true);
            Time.timeScale = 1;
        }
	}

    public void OnUnPause()
    {
        paused = false;
    }
    //connected to pause button
    public void OnPause()
    {
        paused = true;
    }
    
    public void Resume()
    {
        paused = false;
    }
    // probably don't want a restart for this game 
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

