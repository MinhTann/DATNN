using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
     public Shopmanager shopManager;
    public Inventory inventoryManager;

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("PlayerMoney", shopManager.playerMoney);

        for (int i = 0; i < inventoryManager.inventoryItems.Count; i++)
        {
            PlayerPrefs.SetInt("Item_" + inventoryManager.inventoryItems[i].itemName, inventoryManager.inventoryItems[i].quantity);
        }
        PlayerPrefs.Save();
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerMoney"))
        {
            shopManager.playerMoney = PlayerPrefs.GetInt("PlayerMoney");
        }

        foreach (var item in inventoryManager.inventoryItems)
        {
            if (PlayerPrefs.HasKey("Item_" + item.itemName))
            {
                item.quantity = PlayerPrefs.GetInt("Item_" + item.itemName);
            }
        }
    }
}
