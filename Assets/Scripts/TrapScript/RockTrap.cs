using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrap : MonoBehaviour
{
    #region Expose
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject _lockCollider;
    #endregion

    #region Unity Life Cycle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _lockCollider.SetActive(false);
            _collider.isTrigger = true;
        }
    }
    #endregion
}
