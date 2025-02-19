using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBossDamageBuff", menuName = "Buffs/BossDamageBuff")]
public class BossDamageBuffSO : ScriptableObject
{
    [Header("Thông tin Buff")]
    public string buffName = "Tăng Dame Boss";
    public float damageMultiplier = 2f; // x2 sát thương
    public float duration = 5f;        // Thời gian hiệu lực
}