using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootButton : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    //public Item item;

    public Image Icon
    {
        get { return icon; }
    }
    
    public TextMeshProUGUI Title
    {
        get { return title; }
    }

    //public void AddItemInventory()
    //{
    //    InventoryManager.Instance.Add(item);
    //    Destroy(gameObject);
    //}

}
