using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawUponEndTurn : MonoBehaviour
{

    public GameObject[] Cards;
    GameObject ImageClone;


    public void Lul() {
        GameObject Panel = GameObject.Find("Panel");
        Cards = new GameObject[4];
        Cards[0] = GameObject.Find("Image");
        Cards[1] = GameObject.Find("Image (1)");
        Cards[2] = GameObject.Find("Image (2)");
        Cards[3] = GameObject.Find("Image (3)");

        ImageClone = Instantiate(Cards[UnityEngine.Random.Range(0,4)], transform.position, Quaternion.identity) as GameObject;
        ImageClone.transform.parent = Panel.transform;
    }
}
