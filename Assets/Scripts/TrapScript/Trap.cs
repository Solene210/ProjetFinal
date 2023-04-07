using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    #region Expose
    [SerializeField] private Transform[] _respawnPoint;
    #endregion

    #region Unity Life Cycle
    private void OnTriggerEnter(Collider other)
    {
        int randomPointSpawn = Random.Range(0, _respawnPoint.Length);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = _respawnPoint[randomPointSpawn].position;
            Debug.Log(randomPointSpawn);
        }
    }
    #endregion
}