using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangingScripts : MonoBehaviour
{
    public string[] recipe;
    public Sprite[] recipeImages;
    public TMP_Text displayedText;
    public Image help;
    private int currentPage;

    // Start is called before the first frame update
    void Start()
    {
        displayedText.text = recipe[0];
        //help.sprite = recipeImages[0];
        currentPage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void textSwitchLeft()
    {
        if(currentPage > 0)
        {
            currentPage -= 1;
            displayedText.text = recipe[currentPage];
            //help.sprite = recipeImages[currentPage];
        }
    }
    public void textSwitchRight()
    {
        if (currentPage < recipe.Length - 1)
        {
            currentPage += 1;
            displayedText.text = recipe[currentPage];
            //help.sprite = recipeImages[currentPage];
        }
    }
}
