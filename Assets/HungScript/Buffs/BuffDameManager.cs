using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDameManager : MonoBehaviour
{  
    [Header("Buff Cấu Hình")]
    public BossDamageBuffSO bossDamageBuff;

    [Header("Tham chiếu Vũ Khí")]
    public PlayerWeapon playerWeapon;

    private bool isBuffed = false;
    private float originalDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isBuffed)
        {
            StartCoroutine(ApplyBuff());
        }
    }

    private IEnumerator ApplyBuff()
    {
         BuffUIManager.Instance.ShowBuffUI("Buff Dame Boss", bossDamageBuff.duration);
    
    isBuffed = true;
    originalDamage = playerWeapon.bossDamage;
    playerWeapon.bossDamage *= bossDamageBuff.damageMultiplier;

    yield return new WaitForSeconds(bossDamageBuff.duration);

    playerWeapon.bossDamage = originalDamage;
    isBuffed = false;
    }
}
