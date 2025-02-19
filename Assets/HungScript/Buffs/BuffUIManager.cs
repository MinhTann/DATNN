using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BuffUIManager : MonoBehaviour
{
    public static BuffUIManager Instance;

    [Header("Tham chiếu UI")]
    public Canvas buffCanvas;    
    public TMP_Text buffText;    

    private Coroutine hideCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        // Ẩn canvas ngay khi game bắt đầu
        buffCanvas.enabled = false;
    }

    public void ShowBuffUI(string buffName, float duration)
    {
        buffText.text = $"Đang Buff: {buffName} - {duration:F1} giây";
        buffCanvas.enabled = true;

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }
        hideCoroutine = StartCoroutine(HideCanvasAfter(duration));
    }

    private IEnumerator HideCanvasAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        yield return new WaitForSeconds(1f);
        buffCanvas.enabled = false;
    }
}
