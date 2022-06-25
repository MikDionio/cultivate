using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipHover : MonoBehaviour
{
    public GameObject tooltipCanvas;
    public TextMeshProUGUI tooltipText;
    public string text;
    private void OnMouseEnter()
    {
        tooltipCanvas.SetActive(true);
        tooltipText.text = text;
    }

    private void OnMouseExit()
    {
        tooltipCanvas.SetActive(false) ;
        tooltipText.text = null;
    }
}
