using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Sát thương vũ khí")]
    public float bossDamage = 10f;

   /*public void AttackBoss(GameObject boss)
    {
        if (boss.TryGetComponent<BossHealth>(out var bossHealth))
        {
            bossHealth.TakeDamage(bossDamage);
        }
    }*/
}
