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
    public int gemReward;
    public QuestGoal goal;
    [SerializeField] private GameObject _victoryPanel;
    #endregion

    #region methods
    public void Complete()
    {
        isActive = false;
        Debug.Log(title + "was completed!");
        _victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion
}
