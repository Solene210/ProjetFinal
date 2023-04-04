using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrap : MonoBehaviour
{
    #region Expose
    [SerializeField] private int _damage;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private FeedBackLavaDamage _feedBack;
    #endregion

    #region Unity Life Cycle
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _health.ApplyLavaDamage(_damage);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _feedBack._feedBackEnd.Invoke();
    }
    #endregion
}
