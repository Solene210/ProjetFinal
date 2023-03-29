using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Expose
    public static PlayerHealth Instance;
    public int health = 5;
    public int experience = 40;
    public int gold = 1000;
    public Quest quest;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI expText;
    [SerializeField] private GameObject gameOverPanel;
    #endregion

    #region Unity Life Cycle
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        healthText.text = $"HP : {health}";
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
    public void DecreaseHealth(int value)
    {
        health -= value;
        healthText.text = $"HP : {health}";
        if (health == 0)
        {
            GameOver();
        }
    }

    public void IncreaseHealth(int value)
    {
        health += value;
        healthText.text = $"HP : {health}";
    }
    
    public void IncreaseExp(int value)
    {
        experience += value;
        expText.text = $"HP : {experience}";
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    #endregion

    #region Private & Protected

    #endregion
}
