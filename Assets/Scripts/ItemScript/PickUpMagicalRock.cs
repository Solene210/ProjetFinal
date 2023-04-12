using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMagicalRock : MonoBehaviour
{
    #region Expose
    public Item item;
    //public Quest quest;
    public int gem = 0;
    [SerializeField] private GameObject _victoryPanel;
    #endregion

    #region Unity Life Cycle
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }
    #endregion

    #region methods
    private void PickUp()
    {
        MagicRockInventoryManager.Instance.Add(item);
        
        Destroy(gameObject);
        QuestGiver questGiver = GameObject.Find("QuestGiver").GetComponent<QuestGiver>();
        if(questGiver.quest.isActive == false)
        {
            Victory();
        }
    }

    private void Victory()
    {
        Cursor.lockState = CursorLockMode.None;
        _victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion
}
