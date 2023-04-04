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
    public TextMeshProUGUI gemText;
    [SerializeField] private GameObject _dialogueCamera;
    [Space]
    [Header("Event")]
    public UnityEvent EndDialogueEvent;
    #endregion

    #region methods
    public void CallQuestWindow()
    {
#if LOG_EVENT
        Debug.Log("ajout du listener OpenQuest");
#endif
        EndDialogueEvent.AddListener(OpenQuestWindow);
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        gemText.text = quest.gemReward.ToString();
    }

    public void AcceptQuest()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _dialogueCamera.SetActive(false);
        questWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
        Debug.Log("la quête a été accepté");
    }
#endregion
}
