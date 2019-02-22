using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DifficultySelection : MonoBehaviour
{
    public int difAdd = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Easy()
    {
        difAdd = 0;
        PlayerPrefs.SetInt("DifAdd", difAdd);
        SceneManager.LoadScene("MainMenu");
    }
    public void Medium()
    {
        difAdd = 10;
        PlayerPrefs.SetInt("DifAdd", difAdd);
        SceneManager.LoadScene("MainMenu");
    }
    public void Hard()
    {
        difAdd = 20;
        PlayerPrefs.SetInt("DifAdd", difAdd);
        SceneManager.LoadScene("MainMenu");
    }
}
