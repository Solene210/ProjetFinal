using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI _gemText;
    #endregion

    #region methods
    public void Complete()
    {
        if (goal.IsReached())
        {
            isActive = false;
            Debug.Log(title + "was completed!");
            GemPickUp gemPickUp = GameObject.FindWithTag("Gem").GetComponent<GemPickUp>();
            _gemText.text = (gemReward + gemPickUp.gem.value).ToString();
            _victoryPanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    #endregion
}
