using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWindow : MonoBehaviour
{
    #region Expose
    [SerializeField] private LootButton[] lootButtons;
    //For debug will be remove later
    [SerializeField] private Item[] _items;
    #endregion

    #region Unity Life Cycle
    private void Awake()
    {
        
    }

    void Start()
    {
        AddLoot();
    }

    #endregion

    #region methods
    private void AddLoot()
    {
        //Set the loot button icon
        lootButtons[0].Icon.sprite = _items[0].icon;
        //Make sure the loot buttons is visible
        lootButtons[0].gameObject.SetActive(true);
        //Set the title
        lootButtons[0].Title.text = _items[0]._name;
    }

    public void CloseWIndow()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion

    #region Private & Protected

    #endregion
}
