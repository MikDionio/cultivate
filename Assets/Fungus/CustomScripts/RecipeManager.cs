using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeManager : MonoBehaviour
{
    public List<Recipe> RecipeList;

    //Recipe List + Failed List Variables
    public TextMeshProUGUI title, ingredients, description, directions;
    public Image sprite;
    public GameObject recipeButtonParent, RecipeButtonPrefab, failedParent, failedPrefab;

    //Pop up Variables
    public GameObject repeatedCanvas, newPotionCanvas;
    public TextMeshProUGUI repeatedTitle, newPotionTitle, newPotionDescription;
    public Image repeatedSprite, newPotionSprite;
    public Sprite specialPotion, normalPotion, dudPotion;

    //Unlocking new potion
    private int unlockedSpecialPotions=0;
    public GameObject labDrawer, potionDisplay, specialPotionPrefab;
    public RequestManager requestManager;

    public void Mix(string ingredient1, string ingredient2)
    {
        List<Recipe> checkIngredient1 = RecipeList.FindAll(x => x.ingredient1 == ingredient1 || x.ingredient1 == ingredient2);
        Recipe potion = checkIngredient1.Find(x => x.ingredient2 == ingredient1 || x.ingredient2 == ingredient2);

        if (potion)
        {
            if (!potion.unlocked)
            {
                potion.unlockRecipe();
                AddToRecipeList(potion);

                newPotionTitle.text = potion.name;
                newPotionDescription.text = potion.description;

                if (potion.request)
                {
                    unlockedSpecialPotions++;
                    if (unlockedSpecialPotions >= 3)
                    {
                        labDrawer.SetActive(false);
                        potionDisplay.SetActive(true);
                    }

                    //
                    if (!potion.request.completed)
                    {
                        potion.request.CompleteRequest(potion);
                        requestManager.CompleteRequest(potion.request);

                        potionDisplay.transform.Find(potion.name).gameObject.SetActive(true);
                    }
                    
                }
                
                newPotionSprite.sprite = potion.sprite;
                
                newPotionCanvas.SetActive(true);

            }
            else
            {
                if (potion.name == null)
                {
                    repeatedSprite.sprite = dudPotion;
                    repeatedTitle.text = "Dud Item";
                }
                else
                {
                    repeatedSprite.sprite = potion.sprite;
                    repeatedTitle.text = potion.name;
                }
                repeatedCanvas.SetActive(true);
            }
            
        }
        else
        {
            Recipe newRecipe = Recipe.CreateInstance<Recipe>();
            newRecipe.ingredient1 = ingredient1;
            newRecipe.ingredient2 = ingredient2;
            newRecipe.unlockRecipe();
            RecipeList.Add(newRecipe);
            AddToFailedList(newRecipe);

            newPotionTitle.text = "Dud Item";
            newPotionDescription.text = "It certainly looks lethal, but it probably won't be useful for husband-killing.";
            newPotionSprite.sprite = dudPotion;
            newPotionCanvas.SetActive(true);
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
