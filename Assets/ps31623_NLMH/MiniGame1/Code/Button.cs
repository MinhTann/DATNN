using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(ReturnToMainMenu);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Exit"); 
    }
}