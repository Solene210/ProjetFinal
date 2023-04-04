using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    #region Expose
    [SerializeField] private int _damage;
    #endregion

    #region Unity Life Cycle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.DecreaseHealth(_damage);
        }
    }
    #endregion
}
