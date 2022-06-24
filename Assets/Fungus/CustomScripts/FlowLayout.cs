using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowLayout : MonoBehaviour
{
    public float width;

    // Use this for initialization
    void Start()
    {
        width = this.gameObject.GetComponent<RectTransform>().rect.width;
        Vector2 newSize = new Vector2(width / 2, width / 2);
        this.gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}
