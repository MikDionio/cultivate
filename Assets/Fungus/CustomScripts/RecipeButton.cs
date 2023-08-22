using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RecipeButton : MonoBehaviour
{
    public Recipe recipe;
    public TextMeshProUGUI title, ingredients, description, directions;
    public Image sprite;

    public void UpdateRecipeRight()
    {
        title.text =recipe.name;
        ingredients.text = recipe.ingredient1 + " + " + recipe.ingredient2;
        description.text = recipe.description;
        directions.text = recipe.directions;
        sprite.sprite = recipe.sprite;
        sprite.gameObject.SetActive(true);
    }
    
}
