using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PineTree : MonoBehaviour
{
    public TextMeshProUGUI starText; 
    public List<TextMeshProUGUI> ballTexts; 
    public UIManager uiManager; 

    void Start()
    {
        SetDivisors();
    }

    void SetDivisors()
    {
        int number = GetRandomNumberWithSixDivisors();
        starText.text = number.ToString();

        List<int> divisors = GetDivisors(number);
        divisors.Sort((a, b) => b.CompareTo(a)); 

        List<int> selectedDivisors = SelectRandomDivisors(divisors);

        HashSet<int> questionMarkIndices = new HashSet<int>();
        while (questionMarkIndices.Count < 2)
        {
            int randomIndex = Random.Range(0, ballTexts.Count);
            questionMarkIndices.Add(randomIndex);
        }

        int divisorIndex = 0;
        for (int i = 0; i < ballTexts.Count; i++)
        {
            if (questionMarkIndices.Contains(i))
            {
                ballTexts[i].text = "?";
            }
            else
            {
                ballTexts[i].text = selectedDivisors[divisorIndex].ToString();
                divisorIndex++;
            }
        }

        uiManager.Initialize(number, selectedDivisors);
    }

    int GetRandomNumberWithSixDivisors()
    {
        int number;
        do
        {
            number = Random.Range(1, 101); 
        } while (GetDivisors(number).Count < 6);
        return number;
    }

    List<int> GetDivisors(int number)
    {
        List<int> divisors = new List<int>();
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                divisors.Add(i);
        }
        return divisors;
    }

    List<int> SelectRandomDivisors(List<int> divisors)
    {
        List<int> selectedDivisors = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            selectedDivisors.Add(divisors[i]);
        }
        return selectedDivisors;
    }
}


