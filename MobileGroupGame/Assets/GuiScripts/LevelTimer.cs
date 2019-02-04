using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour {

    float levelTimer = 100;
    public Text timerText;
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        levelTimer -= Time.deltaTime;
        timerText.GetComponent<Text>().text = "Time Left:" + levelTimer;
        if (levelTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
