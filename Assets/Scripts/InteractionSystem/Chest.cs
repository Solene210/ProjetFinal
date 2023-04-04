using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    #region Expose
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Openig chest");
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
