using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonForLookingAtCard : MonoBehaviour, IPointerDownHandler { 

    public void OnPointerDown(PointerEventData eventData)
    {
        Canvas d = GetComponent<Canvas>();
        if (d.enabled == true)
        {
            d.enabled = false;
        }
    }





}

