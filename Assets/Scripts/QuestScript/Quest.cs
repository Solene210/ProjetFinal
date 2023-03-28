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
    public int experienceReward;
    public int goldReward;
    public QuestGoal goal;
    #endregion

    #region Unity Life Cycle

    #endregion

    #region methods
    public void Complete()
    {
        isActive = false;
        Debug.Log(title + "was completed!");
    }
    #endregion

    #region Private & Protected
    
    #endregion
}
