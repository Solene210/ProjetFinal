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
    private GameObject _target;
    readonly Item item;
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
        if(goalType == GoalType.MagicRock)
        {
            if (item.type == Item.ItemType.MagicRock)
            {
                item.value = currentAmount;
                currentAmount++;
            }
        }
    }
    #endregion
}

public enum GoalType
{
    Kill,
    MagicRock
}
