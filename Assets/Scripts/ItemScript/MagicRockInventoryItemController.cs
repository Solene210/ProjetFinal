using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MagicRockInventoryItemController : MonoBehaviour
{
    #region Expose
    Item item;
    #endregion

    #region methods
    public void AddItem(Item newItem)
    {
        item = newItem;
    }
    #endregion
}
