#define LOG_EVENT
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public GameObject dialogueButton;
    public QuestGiver questGiver;
    [SerializeField] private GameObject _dialogueCamera;

    #region Unity Life Cycle
    void Start()
    {
        _sentences= new Queue<string>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion

    #region Methods
    public void StartDialogue(Dialogue dialogue)
    {
        _dialogueCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        dialogueBox.SetActive(true);
        dialogueButton.SetActive(false);
        nameText.text = dialogue.name;
        _sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueButton.SetActive(true);
#if LOG_EVENT
        Debug.Log("endDialogueEvent est invoqué");
#endif
        questGiver.EndDialogueEvent?.Invoke();
    }
    #endregion

    #region Private & Protected
    private Queue<string> _sentences;
    #endregion
}
