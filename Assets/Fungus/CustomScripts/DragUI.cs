using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour
{
    public Canvas parent;
    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)parent.transform,
            pointerData.position,
            parent.worldCamera,
            out position);
        print(position);
        transform.position = parent.transform.TransformPoint(position);
    }
}
