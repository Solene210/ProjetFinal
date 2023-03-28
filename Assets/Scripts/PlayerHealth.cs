using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Expose
    public int health = 5;
    public int experience = 40;
    public int gold = 1000;
    public Quest quest;
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
    public void GoBattle()
    {
        health -= 1;
        experience += 2;
        gold += 5;

        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                experience += quest.experienceReward;
                gold += quest.goldReward;
                quest.Complete();
            }
        }
    }
    #endregion

    #region Private & Protected
    
    #endregion
}
