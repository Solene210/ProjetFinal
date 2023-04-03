using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    #region Expose
    Item item;
    #endregion

    #region methods
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.type)
        {
            case Item.ItemType.MagicRock:
                break;
            case Item.ItemType.Potion:
                PlayerHealth.Instance.IncreaseHealth(item.value);
                break;
        }
        RemoveItem();
    }
    #endregion
}
