using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChonAnh : MonoBehaviour
{
    [SerializeField] private string minigameSceneName = "MinigameScene"; // Tên scene minigame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nếu nhân vật chạm vào
        {
            Debug.Log("Nhân vật đã chạm vào cổng, chuyển sang minigame...");
            SceneManager.LoadScene(minigameSceneName); // Chuyển đến scene minigame
        }
    }
}
