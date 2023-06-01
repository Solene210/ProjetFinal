using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour, IInteractable
{
    #region Expose
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private int _numFound;
    [SerializeField] private GameObject _openImage;
    #endregion

    #region Unity Life Cycle
    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        if(_numFound > 0)
        {
            Interact();
        }
        else
        {
            StopInteract();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

    public void Interact()
    {
        var interactable = _colliders[0];
        _openImage.SetActive(true);
        if (interactable != null && Input.GetKey(KeyCode.F))
        {
            //interactable.Interact(this);
        }
    }

    public void StopInteract()
    {
        _openImage.SetActive(false);
    }

    public bool Interact(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region methods

    #endregion

    #region Private & Protected
    private readonly Collider[] _colliders = new Collider[3];

    public string InteractionPrompt => throw new System.NotImplementedException();
    #endregion
}
