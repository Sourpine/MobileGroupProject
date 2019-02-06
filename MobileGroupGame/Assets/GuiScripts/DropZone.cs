using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {


    public DragCard.Slot typeOfItem = DragCard.Slot.WEAPON;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        DragCard d = eventData.pointerDrag.GetComponent<DragCard>();
        if(d != null)
        {
            if (typeOfItem == d.typeOfItem)
            {
                d.parentToReturnTo = this.transform;
            }
            
           
            
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Okay, champ");
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Okay, champ2");
    }
	
}
