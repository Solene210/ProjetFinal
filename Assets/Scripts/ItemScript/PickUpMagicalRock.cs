using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMagicalRock : MonoBehaviour
{
    #region Expose
    public Item item;
    //public Quest quest;
    //public int gem = 0;
    [SerializeField] private GameObject _victoryPanel;
    #endregion

    #region Unity Life Cycle
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if (quest.isActive)
            //{
            //    quest.goal.currentAmount++;
            //    quest.goal.CollectMagicRock();
            //    if (quest.goal.IsReached())
            //    {
            //        gem += quest.gemReward;
            //        quest.Complete();
            //    }
            //}
            PickUp();
        }
    }
    #endregion

    #region methods
    private void PickUp()
    {
        //InventoryManager.Instance.Add(item);
        MagicRockInventoryManager.Instance.Add(item);
        
        Destroy(gameObject);
        Victory();
    }

    private void Victory()
    {
        Cursor.lockState = CursorLockMode.None;
        _victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion
}
