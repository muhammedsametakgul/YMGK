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
    private List<TextMeshProUGUI> ballTexts;
    private HashSet<int> questionMarkIndices;
    private HashSet<int> correctGuesses = new HashSet<int>();

    void Start()
    {
        checkButton.onClick.AddListener(CheckAnswer);
    }

    public void Initialize(int number, List<int> divisors, List<TextMeshProUGUI> ballTexts, HashSet<int> questionMarkIndices)
    {
        starNumber = number;
        ballDivisors = new List<int>(divisors);
        this.ballTexts = ballTexts;
        this.questionMarkIndices = questionMarkIndices;
    }

    public void CheckAnswer()
{
    string input = inputField.text.Trim(); 

    Debug.Log("Kullanıcı Girişi: " + input); 

    if (int.TryParse(input, out int userInput))
    {
        if (correctGuesses.Contains(userInput))
        {
            feedbackText.text = "Bu sayı zaten doğru olarak tahmin edildi.";
        }
        else if (starNumber % userInput == 0)
        {
            feedbackText.text = "Doğru! Girdiğiniz sayı yıldızdaki sayıyı tam bölebiliyor.";
            correctGuesses.Add(userInput);

            bool updated = UpdateQuestionMarkSlot(userInput);
            if (!updated)
            {
                feedbackText.text = "Tüm soru işaretleri zaten güncellenmiş.";
            }
        }
        else
        {
            feedbackText.text = "Yanlış! Girdiğiniz sayı yıldızdaki sayıyı tam bölemiyor.";
        }

        inputField.text = "";
    }
    else
    {
        feedbackText.text = "Lütfen geçerli bir sayı girin.";
    }
}

private bool UpdateQuestionMarkSlot(int correctNumber)
{
    foreach (int index in questionMarkIndices)
    {
        if (ballTexts[index].text == "?")
        {
            ballTexts[index].text = correctNumber.ToString();
            questionMarkIndices.Remove(index);
            return true;
        }
    }
    return false; 
}


}
