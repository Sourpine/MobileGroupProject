using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeDiff : MonoBehaviour
{
    public int playerHP = 0;
    public int levSub = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("LevSub", levSub);
        //levSub = PlayerPrefs.GetInt("LevSub");
        //Debug.Log("it has been subtracted");
        playerHP = PlayerPrefs.GetInt("PlayerHP", playerHP);
        PlayerPrefs.GetInt("PlayerHP", playerHP);
        //SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            playerHP -= 5;
        }
        if (SceneManager.GetActiveScene().name == "Level03")
        {
            playerHP -= 10;
        }
        //playerHP -= levSub;
        PlayerPrefs.GetInt("PlayerHP", playerHP);
        //playerHP = PlayerPrefs.GetInt("PlayerHP", playerHP);
        //Debug.Log("it has been subtracted");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
