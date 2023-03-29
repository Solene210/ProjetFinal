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
            dialogueButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueButton.gameObject.SetActive(false);
        }
    }
    #endregion

    #region methods

    #endregion

    #region Private & Protected

    #endregion
}
