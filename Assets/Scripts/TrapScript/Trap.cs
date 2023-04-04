using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    #region Expose
    [SerializeField] private Transform _respawnPoint;
    #endregion

    #region Unity Life Cycle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = _respawnPoint.position;
        }
    }
    #endregion
}