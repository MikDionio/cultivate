using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Request", menuName = "Request")]
public class Request : ScriptableObject
{
    public new string name;
    public Sprite housewifeSprite;
    public string text;
    [TextArea(3, 10)]
    public string defaultText;
    public Recipe recipe;
    public bool completed;
    public int requestNumber;
    private void OnEnable()
    {
        completed = false;
        recipe = null;
        text = defaultText;
    }

    public void CompleteRequest(Recipe potion)
    {
        completed = true;
        text = potion.completedText;
        recipe = potion; 
    }
}
