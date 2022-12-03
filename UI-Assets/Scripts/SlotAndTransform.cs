using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotAndTransform : MonoBehaviour, IDropHandler
{
    public Sprite leftHalf;
    public Sprite rightHalf;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount < 2)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            if (transform.childCount == 0)
            {
                //draggableItem.gameObject.GetComponent<SpriteRenderer>().sprite = leftHalf;
                draggableItem.image.sprite = leftHalf;
            }
            if (transform.childCount == 1)
            {
                //draggableItem.gameObject.GetComponent<SpriteRenderer>().sprite = rightHalf;
                draggableItem.image.sprite = rightHalf;
            }
        }
    }
}