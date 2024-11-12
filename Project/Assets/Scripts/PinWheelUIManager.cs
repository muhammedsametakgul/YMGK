/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinWheelUIManager : MonoBehaviour
{
    public PinWheel pinWheel; // PinWheel referansı
    public TMP_InputField inputField1; // İlk indeks girişi
    public TMP_InputField inputField2; // İkinci indeks girişi
    public TextMeshProUGUI resultText; // Sonuç metnini göstermek için
    public Button checkButton; // Kontrol butonu

    void Start()
    {
        // Butona tıklanıldığında CheckMatch fonksiyonunu çağır
        checkButton.onClick.AddListener(CheckMatch);
    }

    void CheckMatch()
    {
        // Kullanıcı girişlerini al
        string input1 = inputField1.text;
        string input2 = inputField2.text;

        // Girişlerin boş olmadığını kontrol et
        if (string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2))
        {
            resultText.text = "Lütfen her iki giriş alanına da bir sayı girin.";
            return;
        }

        // Girişleri integer'a dönüştür
        int index1, index2;
        if (!int.TryParse(input1, out index1) || !int.TryParse(input2, out index2))
        {
            resultText.text = "Lütfen geçerli sayılar girin.";
            return;
        }

        // Girilen indekslerin geçerli olup olmadığını kontrol et
        if (index1 < 1 || index1 > pinWheel.windmills.Length || index2 < 1 || index2 > pinWheel.windmills.Length)
        {
            resultText.text = "Girilen indeksler geçersiz. 1 ile " + pinWheel.windmills.Length + " arasında olmalı.";
            return;
        }

        // Indeksleri sıfırdan başlayan dizi indeksine göre ayarla
        index1 -= 1;
        index2 -= 1;

        // Kullanıcının girdiği indeksleri aynı materyale sahip indekslerle karşılaştır
        if ((index1 == pinWheel.sameMaterialIndex1 && index2 == pinWheel.sameMaterialIndex2) ||
            (index1 == pinWheel.sameMaterialIndex2 && index2 == pinWheel.sameMaterialIndex1))
        {
            resultText.text = "Doğru bildin! Bu rüzgar gülleri aynı materyale sahip.";
        }
        else
        {
            resultText.text = "Yanlış! Bu rüzgar gülleri farklı materyallere sahip.";
        }
    }
} */