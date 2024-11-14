using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragableItem : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public Image image;
    public Sprite[] Sprites;
    public Chapter1Flow.CLUES ClueType;
    [HideInInspector] public Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        this.transform.parent.GetComponent<InventorySlot>().SuccessMapped = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        Vector2 tarPos = Input.mousePosition;
        //tarPos.x += Screen.width ;
        tarPos.y -= Screen.height;
        transform.GetComponent<RectTransform>().anchoredPosition = tarPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        transform.localPosition = Vector3.zero;
        image.raycastTarget = true;
        if(this.transform.parent.GetComponent<InventorySlot>().ShouldTransformToText)
        {
            this.GetComponent<Image>().sprite = Sprites[1];
            this.GetComponent<RectTransform>().localScale = new Vector3(5, 5, 5);
            if(this.transform.parent.GetComponent<InventorySlot>().SuccessMapped)
            {
                this.GetComponent<Image>().raycastTarget = false;
            }
        }
        else
        {
            this.GetComponent<Image>().sprite = Sprites[0];
            this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

   
}
