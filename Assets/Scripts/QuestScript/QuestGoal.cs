using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    #region Expose
    public GoalType goalType;
    public int requiredAdmount;
    public int currentAmount;

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
    public bool IsReached()
    {
        return (currentAmount >= requiredAdmount);
    }

    public void EnemyKilled()
    {
        if(goalType == GoalType.Kill)
        {
            currentAmount++;
        }
    }
    public void ItemCollected()
    {
        if(goalType == GoalType.Gathering)
        {
            currentAmount++;
        }
    }
    #endregion

    #region Private & Protected
    
    #endregion
}

public enum GoalType
{
    Kill,
    Gathering
}
