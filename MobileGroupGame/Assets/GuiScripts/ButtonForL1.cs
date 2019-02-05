using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForL1 : MonoBehaviour
{
    public void ChampBigStickSS()
    {
        GameObject.Find("Panel").GetComponent<Image>().enabled = true;
        GameObject.Find("Image (1)").GetComponent<Image>().enabled = true;
        GameObject.Find("Image").GetComponent<Image>().enabled = true;
        GameObject.Find("Image (3)").GetComponent<Image>().enabled = true;
        GameObject.Find("Image (2)").GetComponent<Image>().enabled = true;




    }
}
