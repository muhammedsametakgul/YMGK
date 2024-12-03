using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PinWheelUIManager : MonoBehaviour
{
    public PinWheel pinWheel;
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TextMeshProUGUI resultText;
    public Button checkButton;
    public AudioClip correctSound;  
    public AudioClip incorrectSound;  
    private AudioSource audioSource;  

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        checkButton.onClick.AddListener(CheckMatch);
    }

    void CheckMatch()
    {
        string input1 = inputField1.text;
        string input2 = inputField2.text;

        resultText.text = "";

        if (string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2))
        {
            resultText.text = "Lütfen her iki giriş alanına da bir sayı girin.";
            StartCoroutine(HideResultTextAfterDelay());
            return;
        }

        int index1, index2;
        if (!int.TryParse(input1, out index1) || !int.TryParse(input2, out index2))
        {
            resultText.text = "Lütfen geçerli sayılar girin.";
            StartCoroutine(HideResultTextAfterDelay());
            return;
        }

        if (index1 < 1 || index1 > pinWheel.windmills.Length || index2 < 1 || index2 > pinWheel.windmills.Length)
        {
            resultText.text = "Girilen sayılar geçersiz. 1 ile " + pinWheel.windmills.Length + " arasında olmalı.";
            StartCoroutine(HideResultTextAfterDelay());
            return;
        }

        index1 -= 1;
        index2 -= 1;

        if ((index1 == pinWheel.sameMaterialIndex1 && index2 == pinWheel.sameMaterialIndex2) || 
            (index1 == pinWheel.sameMaterialIndex2 && index2 == pinWheel.sameMaterialIndex1))
        {
            resultText.text = "Rüzgar Gülleri Aynı";
            if (audioSource != null && correctSound != null)
            {
                audioSource.PlayOneShot(correctSound);
            }
        }
        else
        {
            resultText.text = "Yanlış! Bu Rüzgar Gülleri Farklı";
            if (audioSource != null && correctSound != null)
            {
                audioSource.PlayOneShot(incorrectSound);
            }
        }

        pinWheel.CreateWindmills();

        inputField1.text = "";
        inputField2.text = "";

        StartCoroutine(HideResultTextAfterDelay());
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    IEnumerator HideResultTextAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        resultText.text = "";
    }
}
