using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public string ingredient1;
    public string ingredient2;
    public string description;
    public string directions;
    public bool unlocked;
    public int requestNumber = 0;
}
