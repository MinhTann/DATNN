using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public InventoryItem healthPotion;
    public int healAmount = 50;
    public Text hpText; // Hiển thị HP
    private int playerHP = 100;
    private int maxHP = 100;

    public void UseHealthPotion()
    {
        if (healthPotion.quantity > 0 && playerHP < maxHP)
        {
            playerHP += healAmount;
            if (playerHP > maxHP) playerHP = maxHP;

            healthPotion.quantity--;
            UpdateHPUI();
            Debug.Log("Đã sử dụng Health Potion!");
        }
        else
        {
            Debug.Log("Không thể sử dụng!");
        }
    }

    void UpdateHPUI()
    {
        hpText.text = "HP: " + playerHP;
    }
}
