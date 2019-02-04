using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonForL2 : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        d = eventData.OnPointerDown.GetComponent<ButtonForLookingAtCard>();
        if (d.enabled == false)
        {
            d.enabled = true;
        }
    }
}
