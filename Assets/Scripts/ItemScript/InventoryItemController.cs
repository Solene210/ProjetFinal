using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    #region Expose
    Item item;

    public Button removeButton;
    #endregion

    #region Unity Life Cycle
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region methods
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
    #endregion

    #region Private & Protected
    
    #endregion
}
