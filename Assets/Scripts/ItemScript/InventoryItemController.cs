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
            case Item.ItemType.Gem:
                PlayerHealth.Instance.IncreaseExp(item.value);
                break;
        }
        RemoveItem();
    }
    #endregion

    #region Private & Protected
    
    #endregion
}