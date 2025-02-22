using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Shopmanager;

public class BuyButton : MonoBehaviour
{
    private ShopItem item;
    public Shopmanager shopManager;
    private Button button;

    public void Setup(ShopItem shopItem, Shopmanager manager)
    {
        item = shopItem;
        shopManager = manager;
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnBuyButtonClick);
        }
        else
        {
            Debug.LogError("Không tìm thấy Button trên BuyButton.cs!");
        }
    }

 

public void OnBuyButtonClick()
{
    if (item == null)
    {
        Debug.LogError("Lỗi: item trong nút mua bị null!");
        return;
    }

    if (shopManager == null)
    {
        Debug.LogError("Lỗi: shopManager bị null!");
        return;
    }

    Debug.Log("Gọi BuyItem() với item: " + item.itemName);
    shopManager.BuyItem(item);
}

}
