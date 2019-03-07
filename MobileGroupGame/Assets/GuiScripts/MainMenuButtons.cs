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
        SceneManager.LoadScene("Level01");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadLevel02()
    {
        SceneManager.LoadScene("Level02");
    }
    public void LoadLevel03()
    {
        SceneManager.LoadScene("Level03");
    }
}
