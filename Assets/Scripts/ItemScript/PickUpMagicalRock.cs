using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMagicalRock : MonoBehaviour
{
    #region Expose
    public Item item;
    public Quest quest;
    public int gemme = 0;
    [SerializeField] private GameObject _victoryPanel;
    #endregion

    #region Unity Life Cycle
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUp();
            if (quest.isActive)
            {
                quest.goal.CollectMAgicRock();
                if (quest.goal.IsReached())
                {
                    gemme += quest.gemReward;
                    quest.Complete();
                }
            }
        }
    }
    #endregion

    #region methods
    private void PickUp()
    {
        //InventoryManager.Instance.Add(item);
        MagicRockInventoryManager.Instance.Add(item);
        
        Destroy(gameObject);
        //_victoryPanel.SetActive(true);
    }
    #endregion
}
