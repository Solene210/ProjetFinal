using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMagicalRock : MonoBehaviour
{
    #region Expose
    public Item item;
    [SerializeField] private GameObject _victoryPanel;
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
    
    private void OnMouseDown()
    {
        PickUp();
    }
    #endregion

    #region methods

    #endregion

    #region methods
    private void PickUp()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
        _victoryPanel.SetActive(true);
    }
    #endregion

    #region Private & Protected

    #endregion
}
