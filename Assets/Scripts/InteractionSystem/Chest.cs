using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    #region Expose
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject _lootWindow;

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Openig chest");
        _lootWindow.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        return true;
    }
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

    #endregion

    #region Private & Protected
    
    #endregion
}
