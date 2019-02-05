using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForL3 : MonoBehaviour
{

    public void TurnOffThatBoy()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

} 
 






