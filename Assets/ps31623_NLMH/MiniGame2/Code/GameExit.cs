using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("DemoExitButton"); 
    }
}

