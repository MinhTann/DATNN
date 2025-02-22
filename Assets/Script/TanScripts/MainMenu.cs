using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayIntro()
    {
        SceneManager.LoadScene("StoryScene");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScenes");
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
