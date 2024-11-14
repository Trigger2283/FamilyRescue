using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public bool ShouldTransformToText = false;
    public Chapter1Flow.CLUES TargetClues;
    public bool SuccessMapped = false;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) { 
        GameObject dropped = eventData.pointerDrag;
        DragableItem dragableItem = dropped.GetComponent<DragableItem>();
        dragableItem.parentAfterDrag = transform;
        if(ShouldTransformToText && dragableItem.ClueType == TargetClues)
        {
            SuccessMapped = true;
           // this.GetComponentInChildren<Image>().raycastTarget = false;
        }
        else
        {
            SuccessMapped = false;
        }
    }
    }

  
}
