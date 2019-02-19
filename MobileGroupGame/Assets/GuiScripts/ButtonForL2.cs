using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonForL2 : MonoBehaviour
{
    
    public void ChampBigStick()
    {
        GameObject.Find("Panel").GetComponent<Image>().enabled = false;
        GameObject.Find("Image (1)").GetComponent<Image>().enabled = false;
        GameObject.Find("Image").GetComponent<Image>().enabled = false;
        GameObject.Find("Image (3)").GetComponent<Image>().enabled = false;
        GameObject.Find("Image (2)").GetComponent<Image>().enabled = false;
        GameObject.Find("Image (1)(Clone)").GetComponent<Image>().enabled = false;
        GameObject.Find("Image(Clone)").GetComponent<Image>().enabled = false;
        GameObject.Find("Image (3)(Clone)").GetComponent<Image>().enabled = false;
        GameObject.Find("Image (2)(Clone)").GetComponent<Image>().enabled = false;






    }

}
