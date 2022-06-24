using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestManager : MonoBehaviour
{
    public List<Request> requestList = new List<Request>();
    private int currentPage;

    //Recipe Book Variables
    public GameObject nextPage, prevPage;
    public TextMeshProUGUI requestTitle, requestText, potionTitle, potionDescription;
    public Image potionSprite;
    public Sprite lockedPotion;

    public void AddToList(Request request)
    {
        currentPage++;

        requestList.Add(request);
        nextPage.SetActive(false);
        UpdateUI(requestList[currentPage]);

        if (currentPage > 0)
        {
            prevPage.SetActive(true);
        }

    }

    public void NextPage()
    {
        currentPage++;
        UpdateUI(requestList[currentPage]);
        prevPage.SetActive(true);
        if (currentPage == requestList.Count-1)
        {
            nextPage.SetActive(false);
        }
    }

    public void PrevPage()
    {
        currentPage--;
        UpdateUI(requestList[currentPage]);
        nextPage.SetActive(true);
        if (currentPage==1)
        {
            prevPage.SetActive(false);
        }
    }

    public void UpdateUI(Request request)
    {
        requestTitle.text = request.name;
        requestText.text = request.text;

        if (request.recipe)
        {
            potionTitle.text = request.recipe.name;
            potionDescription.text = request.recipe.description;
            potionSprite.sprite = request.recipe.sprite;
        }
        else
        {
            potionTitle.text = null;
            potionDescription.text = null;
            potionSprite.sprite = lockedPotion;
        }
    }

    public void CompleteRequest(Request request)
    {
        currentPage = requestList.Count - 1;
        UpdateUI(request);
        prevPage.SetActive(true);
        nextPage.SetActive(false);
    }

}
