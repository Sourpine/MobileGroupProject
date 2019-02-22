using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffTest : MonoBehaviour
{
    public int health = 20;
    int difAdd = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("DifAdd", difAdd);
        difAdd = PlayerPrefs.GetInt("DifAdd");
        health += difAdd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
