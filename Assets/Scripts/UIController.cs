using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //////////////////////////////////////////////
    //Assignment/Lab/Project: Virtual Pet Game
    //Name: Riley Blackmon
    //Section: SGD.213.2172
    //Instructor: Brian Sowers
    //Date: 02/26/2024
    /////////////////////////////////////////////


    [SerializeField] private Button startButton;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_Text petNameText;
    [SerializeField] private TMP_Text petFullnessText;
    [SerializeField] private TMP_Text petHappinessText;
    [SerializeField] private TMP_Text petEnergyText;
    [SerializeField] private TMP_Text endReasonText;
    Pet userPet;

    // Start is called before the first frame update
    void Start()
    {
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(nameInput.text == "")
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
        }
    }

    public void OnStartButtonClick()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        userPet = new Pet(nameInput.text);
        Debug.Log(userPet.Name);
        Debug.Log(userPet.Fullness);
        Debug.Log(userPet.Happiness);
        Debug.Log(userPet.Energy);
        petNameText.text = userPet.Name;
        petFullnessText.text = $"{userPet.Fullness}";
        petHappinessText.text = $"{userPet.Happiness}";
        petEnergyText.text = $"{userPet.Energy}";
    }

    public void OnFeedButtonClick()
    {
        userPet.FeedPet();
        petFullnessText.text = $"{userPet.Fullness}";
        petHappinessText.text = $"{userPet.Happiness}";
        petEnergyText.text = $"{userPet.Energy}";

        if(userPet.Happiness <= 0 || userPet.Energy <= 0)
        {
            EndGame();
        }
    }

    public void OnPlayButtonClick()
    {
        userPet.PlayWithPet();
        petFullnessText.text = $"{userPet.Fullness}";
        petHappinessText.text = $"{userPet.Happiness}";
        petEnergyText.text = $"{userPet.Energy}";

        if (userPet.Fullness <= 0 || userPet.Energy <= 0)
        {
            EndGame();
        }
    }

    public void OnRestButtonClick()
    {
        userPet.RestPet();
        petFullnessText.text = $"{userPet.Fullness}";
        petHappinessText.text = $"{userPet.Happiness}";
        petEnergyText.text = $"{userPet.Energy}";

        if (userPet.Happiness <= 0 || userPet.Fullness <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        
        if(userPet.Happiness <= 0)
        {
            endReasonText.text = "Your pet was taken! It got too unhappy.";
        }
        else if (userPet.Fullness <= 0)
        {
            endReasonText.text = "Your pet was taken! It got too hungry.";
        }
        else
        {
            endReasonText.text = "Your pet was taken! It got too tired.";
        }
    }

    public void OnRetryButtonClick()
    {
        endPanel.SetActive(false);
        startPanel.SetActive(true);
        nameInput.text = "";
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}