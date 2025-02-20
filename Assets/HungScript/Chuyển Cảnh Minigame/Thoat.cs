using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thoat : MonoBehaviour
{
    [SerializeField] private string mainSceneName = "MainGameScene"; // Tên scene chính

    public void ReturnToMainGame()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
