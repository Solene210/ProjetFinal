using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GemPickUp : MonoBehaviour
{
    #region Expose
    public Gem gem;
    #endregion

    #region Unity Life Cycle
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }
    #endregion

    #region methods
    private void PickUp()
    {
        Destroy(gameObject);
    }
    #endregion
}
