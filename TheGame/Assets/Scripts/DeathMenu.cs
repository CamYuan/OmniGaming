using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public GameObject DeathUI, PauseButton;

    private bool death = false;

    // Use this for initialization
    void Start () {
        DeathUI.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update () {
        if (death)
        {
            DeathUI.SetActive(true);
            Time.timeScale = 0;
            PauseButton.SetActive(false);
        }
  
    }
    public void YouLost()
    {
        death = true;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
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
