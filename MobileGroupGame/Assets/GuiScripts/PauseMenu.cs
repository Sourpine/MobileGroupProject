using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject Canvas;
    public GameObject Orbs;
    public GameObject PM;
    // Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                //make the menu and buttons appear
                GetComponent<Canvas>().enabled = true;
                //pause the game
                Time.timeScale = 0;
                Canvas.SetActive(false);
                Orbs.SetActive(false);
            }
            else if(Time.timeScale == 0)
            {
                Resume();
                Canvas.SetActive(true);
                Orbs.SetActive(true);
            }
            else
            {
                //stare at fridge for an hour
            }
            
        }
    }

    public void Resume()
    {
        GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1;
        Canvas.SetActive(true);
        Orbs.SetActive(true);
        PM.SetActive(false);
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            //make the menu and buttons appear
            PM.SetActive(true);
            //pause the game
            Time.timeScale = 0;
            GetComponent<Canvas>().enabled = false;
            Orbs.SetActive(false);
        }
        else if (Time.timeScale == 0)
        {
            Resume();
            GetComponent<Canvas>().enabled = true;
            Orbs.SetActive(true);
            PM.SetActive(false);
        }
    }
}
