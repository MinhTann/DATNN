using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
  public static CurrencyManager instance;
    public int playerMoney = 100; // Người chơi bắt đầu với 100 xu
    public Text moneyText;

    void Awake() { if (instance == null) instance = this; }

    void Start()
    {
        LoadMoney();
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        playerMoney += amount;
        UpdateMoneyUI();
        SaveMoney();
    }

    public bool SpendMoney(int amount)
    {
        if (playerMoney >= amount)
        {
            playerMoney -= amount;
            UpdateMoneyUI();
            SaveMoney();
            return true;
        }
        return false;
    }

    void UpdateMoneyUI() { moneyText.text = "Money: " + playerMoney; }
    void SaveMoney() { PlayerPrefs.SetInt("PlayerMoney", playerMoney); PlayerPrefs.Save(); }
    void LoadMoney() { if (PlayerPrefs.HasKey("PlayerMoney")) playerMoney = PlayerPrefs.GetInt("PlayerMoney"); }

}
