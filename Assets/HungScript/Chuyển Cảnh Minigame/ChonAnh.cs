using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChonAnh : MonoBehaviour
{
  
    public static bool isMinigameCompleted = false; // Biến lưu trạng thái
    [SerializeField] private string minigameSceneName = "MinigameScene";

    private void Start()
    {
        if (isMinigameCompleted) // Nếu đã hoàn thành minigame, hủy hộp
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(minigameSceneName);
        }
    }
}


