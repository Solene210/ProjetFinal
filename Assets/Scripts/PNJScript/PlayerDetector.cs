using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetector : MonoBehaviour
{
    #region Expose
    [SerializeField] private Button dialogueButton;
    #endregion

    #region Unity Life Cycle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            dialogueButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueButton.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    #endregion
}
