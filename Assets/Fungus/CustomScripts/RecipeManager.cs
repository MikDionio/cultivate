using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeManager : MonoBehaviour
{
    public List<Recipe> RecipeList;
    public TextMeshProUGUI title, ingredients, description, directions;
    public Image sprite;
    public GameObject recipeButtonParent, RecipeButtonPrefab, failedParent, failedPrefab;
    public void Mix(string ingredient1, string ingredient2)
    {
        List<Recipe> checkIngredient1 = RecipeList.FindAll(x => x.ingredient1 == ingredient1);
        Recipe potion = checkIngredient1.Find(x => x.ingredient2 == ingredient2);

        if (potion)
        {
            if (!potion.unlocked)
            {
                potion.unlockRecipe();
                AddToRecipeList(potion);
            }
            
        }
        else
        {
            Recipe newRecipe = Recipe.CreateInstance<Recipe>();
            newRecipe.ingredient1 = ingredient1;
            newRecipe.ingredient2 = ingredient2;
            RecipeList.Add(newRecipe);
            AddToFailedList(newRecipe);
        }

    }

    void AddToRecipeList(Recipe recipe)
    {
        GameObject newButton = Instantiate(RecipeButtonPrefab,recipeButtonParent.transform);
        newButton.name = recipe.name;
        newButton.GetComponent<TextMeshProUGUI>().text = recipe.name;
        RecipeButton buttonComponent = newButton.GetComponent<RecipeButton>();
        buttonComponent.recipe = recipe;
        buttonComponent.title = title;
        buttonComponent.ingredients = ingredients;
        buttonComponent.description = description;
        buttonComponent.directions = directions;
        buttonComponent.sprite = sprite;
    }

    void AddToFailedList(Recipe recipe)
    {
        GameObject newButton = Instantiate(failedPrefab, failedParent.transform);
        newButton.GetComponent<TextMeshProUGUI>().text = recipe.ingredient1 + " + " + recipe.ingredient2;
        
    }
}
