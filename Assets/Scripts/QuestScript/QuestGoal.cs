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
    //public Item item;
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

    public void CollectMagicRock()
    {
        Debug.Log("collectMagicRockCallBack");
        if(goalType == GoalType.MagicRock)
        {
            //item.value = currentAmount;
            currentAmount++;
        }
    }
    #endregion
}

public enum GoalType
{
    Kill,
    MagicRock
}
