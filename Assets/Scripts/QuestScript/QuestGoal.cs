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

    public void CollectMAgicRock()
    {
        if(goalType == GoalType.CollectMagicRock)
        {
            if (GameObject.FindGameObjectWithTag("MagicRock"))
            {
                currentAmount++;
            }
        }
    }
    #endregion
}

public enum GoalType
{
    Kill,
    CollectMagicRock
}
