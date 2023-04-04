using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    #region Expose
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private int _numFound;
    #endregion

    #region Unity Life Cycle
    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();
            if(interactable != null && Input.GetKey(KeyCode.F))
            {
                interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
    #endregion

    #region methods

    #endregion

    #region Private & Protected
    private readonly Collider[] _colliders = new Collider[3];
    #endregion
}
