using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour {

    public GameObject spawnEnemies;
    public Text SpawnText;
    //float SpawnTimer = 5;


    void Start()
    {
        //SpawnText.GetComponent<Text>().text = "Time for Enemies:" + SpawnTimer; 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spawnEnemies.SetActive(true);
            Camera.main.GetComponent<Camera>().fieldOfView = 46;
            //collision.gameObject.tag.MainCamera.GetComponent<Camera>("Field of View", 46);
        }
        /*SpawnTimer -= Time.deltaTime;
        if(SpawnTimer <= 0)
        {
            spawnEnemies.SetActive(false);
        }*/

    }
}
