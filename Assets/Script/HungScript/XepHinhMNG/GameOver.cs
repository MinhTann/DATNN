using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
       
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    // Nút thoát minigame để quay về game chính
    public void ExitMinigame()
    {
        Time.timeScale = 1f; // Chạy lại game
        SceneManager.LoadScene("SampleScene "); // Load lại scene chính
    }
}
