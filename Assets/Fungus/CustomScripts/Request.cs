using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Request", menuName = "Request")]
public class Request : ScriptableObject
{
    public new string name;
    public Sprite housewifeSprite;
    public string text;
    public Recipe recipe;
    public bool completed;
    private void OnEnable()
    {
        completed = false;
    }

    public void completeRequest()
    {
        completed = true;
    }
}
