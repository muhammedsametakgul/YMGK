using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Pinwheel sahnesini açan fonksiyon
    public void LoadPinwheelScene()
    {
        SceneManager.LoadScene("PinwheelGame"); // Sahne adı "PinwheelScene"
    }

    // Pine Tree sahnesini açan fonksiyon
    public void LoadPineTreeScene()
    {
        SceneManager.LoadScene("PinTreeGame"); // Sahne adı "PineTreeScene"
    }

    // Uygulamadan çıkış fonksiyonu
    public void QuitApplication()
    {
        Debug.Log("Uygulama kapatılıyor.");
        Application.Quit();
    
    }
}
