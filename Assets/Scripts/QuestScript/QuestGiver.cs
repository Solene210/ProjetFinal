using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestGiver : MonoBehaviour
{
    #region Expose
    [Header("Quest Parameter")]
    public Quest quest;
    public PlayerHealth player;
    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI gemmeText;
    [Space]
    [Header("Event")]
    public UnityEvent EndDialogue;
    #endregion

    #region methods
    public void LaunchQuest()
    {
        EndDialogue.AddListener(OpenQuestWindow);
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        gemmeText.text = quest.gemmeReward.ToString();
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
    }
    #endregion
}
