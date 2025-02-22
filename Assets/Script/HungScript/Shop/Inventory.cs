using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  public static Inventory instance;
    public List<InventoryItem> inventoryItems;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddItem(InventoryItem item)
    {
        InventoryItem existingItem = inventoryItems.Find(i => i.itemName == item.itemName);
        if (existingItem != null)
        {
            existingItem.quantity++;
        }
        else
        {
            inventoryItems.Add(item);
        }
        Debug.Log("Đã thêm: " + item.itemName);
    }
}
