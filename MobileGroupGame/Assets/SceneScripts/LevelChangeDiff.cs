using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeDiff : MonoBehaviour
{
    public int playerHP = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("PlayerHP", playerHP);
        playerHP = PlayerPrefs.GetInt("PlayerHP", playerHP);
        //SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            playerHP -= 5;
        }
        if (SceneManager.GetActiveScene().name == "Level03")
        {
            playerHP -= 10;
        }
        //PlayerPrefs.GetInt("PlayerHP", playerHP);
        playerHP = PlayerPrefs.GetInt("PlayerHP", playerHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
