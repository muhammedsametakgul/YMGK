using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField inputField; 
    public Button checkButton; 
    public TextMeshProUGUI feedbackText; 

    private int starNumber;
    private List<int> ballDivisors;

    void Start()
    {
        checkButton.onClick.AddListener(CheckAnswer);
    }

    public void Initialize(int number, List<int> divisors)
    {
        starNumber = number;
        ballDivisors = new List<int>(divisors);
    }

  public void CheckAnswer()
{
    int userInput = int.Parse(inputField.text);
    if (userInput != null)
    {
        Debug.Log("Parsed input: " + userInput);

        if (ballDivisors.Contains(userInput))
        {
            feedbackText.text = "Girdiğiniz sayı mevcut toplardaki sayılardan biri.";
        }
        else if (starNumber % userInput == 0)
        {
            feedbackText.text = "Doğru! Girdiğiniz.";
        }
        else
        {
            feedbackText.text = "Yanlış! Girdiğiniz sayı yıldızdaki sayıyı tam bölemiyor.";
        }
    }
    else
    {
        feedbackText.text = "Lütfen geçerli bir sayı girin.";
        Debug.LogWarning("Failed to parse input: " + inputField.text); 
    }

    inputField.text = "";
}
}
