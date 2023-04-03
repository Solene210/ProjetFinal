using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MagicRockInventoryManager : MonoBehaviour
{
    #region Expose
    public static MagicRockInventoryManager Instance;
    public List<Item> items = new List<Item>();
    public Transform itemContent;
    public GameObject InventoryItem;
    public MagicRockInventoryItemController[] magicRockItemsController;
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
        magicRockItemsController = itemContent.GetComponentsInChildren<MagicRockInventoryItemController>();
        for (int i = 0; i < items.Count; i++)
        {
            magicRockItemsController[i].AddItem(items[i]);
        }
    }
    #endregion
}
