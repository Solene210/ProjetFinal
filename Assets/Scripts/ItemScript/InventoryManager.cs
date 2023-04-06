using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    #region Expose
    public static InventoryManager Instance;
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject InventoryItem;
    public InventoryItemController[] inventoryItemsController;
    #endregion

    #region Unity Life Cycle
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region methods
    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItem()
    {
        //Clean content before opening
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemName.text = item._name;
            itemIcon.sprite = item.icon;
        }
        SetInventoryItems();
    }

    public void SetInventoryItems()
    {
        inventoryItemsController = itemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < items.Count; i++)
        {
            inventoryItemsController[i].AddItem(items[i]);
        }
    }
    #endregion
}
