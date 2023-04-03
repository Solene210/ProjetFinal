using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    #region Expose
    public bool isActive;
    public string title;
    public string description;
    public int gemmeReward;
    public QuestGoal goal;
    [SerializeField] private GameObject _victoryPanel;
    #endregion

    #region methods
    public void Complete()
    {
        isActive = false;
        Debug.Log(title + "was completed!");
        _victoryPanel.SetActive(true);
    }
    #endregion
}
