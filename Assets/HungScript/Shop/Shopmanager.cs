using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopmanager : MonoBehaviour
{
    private Shopmanager shopManager;
  public GameObject itemPrefab; // Prefab của mỗi vật phẩm
    public Transform contentPanel; // Panel chứa danh sách vật phẩm
    public Text moneyText; // Hiển thị số tiền
    public int playerMoney = 100; // Số tiền người chơi
    public GameObject shopPanel; // Kéo ShopPanel vào đây

public void CloseShop()
{
    shopPanel.SetActive(false);
}

    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public int price;
        public Sprite icon;
    }

    public List<ShopItem> shopItems; // Danh sách vật phẩm bán trong shop

    void Start()
    {
        UpdateMoneyUI();
    PopulateShop();

    if (shopManager == null)
    {
        shopManager = FindObjectOfType<Shopmanager>();

        if (shopManager == null)
        {
            Debug.LogError("ShopManager không được tìm thấy trong Scene!");
        }
    }
        
    }

    void PopulateShop()
{
    foreach (var item in shopItems)
    {
        GameObject newItem = Instantiate(itemPrefab, contentPanel);
        newItem.transform.Find("ItemName").GetComponent<Text>().text = item.itemName;
        newItem.transform.Find("ItemPrice").GetComponent<Text>().text = "Price: " + item.price;
        newItem.transform.Find("ItemImage").GetComponent<Image>().sprite = item.icon;

        // Tìm nút mua
        Button buyButton = newItem.transform.Find("BuyButton").GetComponent<Button>();
        
        // Xóa tất cả listener cũ trước khi thêm mới (tránh lỗi trùng lặp)
        buyButton.onClick.RemoveAllListeners();
        
        // Dùng Lambda để truyền đúng item
        buyButton.onClick.AddListener(() =>
{
    Debug.Log("Nút mua được nhấn cho: " + item.itemName);
    BuyItem(item);
});


    }
}


 public void BuyItem(ShopItem item)
{
   
    if (playerMoney >= item.price)
    {
        playerMoney -= item.price;
        UpdateMoneyUI();
      
        Debug.Log("Mua thành công: " + item.itemName);
    }
    else
    {
        Debug.Log("Không đủ tiền!");
    }
}
 void UpdateMoneyUI()
    {
        moneyText.text = "Tiền: " + playerMoney;
    }
}
