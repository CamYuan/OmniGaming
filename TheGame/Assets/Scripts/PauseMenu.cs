using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        PauseUI.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        
		if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        //pauses game 
        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        //unpauses game
        if(!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
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
        Application.LoadLevel(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

