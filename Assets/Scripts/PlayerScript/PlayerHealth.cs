using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Expose
    public static PlayerHealth Instance;
    public int health = 5;
    public int gemme = 0;
    public Quest quest;
    public TextMeshProUGUI healthText;
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
    #endregion

    #region methods
    public void GoBattle()
    {
        health -= 1;
        gemme += 5;

        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                gemme += quest.gemmeReward;
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

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    #endregion
}
