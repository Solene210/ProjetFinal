using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();
    public void StopInteract();
    //public string InteractionPrompt { get; }
    //public bool Interact(Interactor interactor);
}
