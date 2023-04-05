using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRockInventoryItemController : MonoBehaviour
{
    #region Expose
    Item item;
    #endregion

    #region methods
    public void RemoveItem()
    {
        MagicRockInventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }
    #endregion
}
