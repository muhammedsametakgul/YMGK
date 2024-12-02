using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadPinwheelScene()
    {
        SceneManager.LoadScene("PinwheelGame"); 
    }

    public void LoadPineTreeScene()
    {
        SceneManager.LoadScene("PinTreeGame"); 
    }

    public void QuitApplication()
    {
        Debug.Log("Uygulama kapatılıyor.");
        Application.Quit();
    
    }
}
