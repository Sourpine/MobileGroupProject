using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    //public int lives = 5;
    void Start() {
        //PlayerPrefs.SetInt("Lives", lives);
    }
    public void NewGame()
    {
        SceneManager.LoadScene("TestONE");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
