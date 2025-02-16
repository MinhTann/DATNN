using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBox : MonoBehaviour
{
    public float buffDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Gọi UI khi nhặt buff
            BuffUIManager.Instance.ShowBuffUI("Buff Dame Boss", buffDuration);
            
            // Thực hiện logic buff dame ở đây
            StartCoroutine(DestroyBuffBox());
        }
    }

    private IEnumerator DestroyBuffBox()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject); // Hủy hộp buff
    }
}
