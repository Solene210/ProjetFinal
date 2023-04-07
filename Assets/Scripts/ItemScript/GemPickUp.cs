using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class GemPickUp : MonoBehaviour
{
    #region Expose
    public Gem gem;
    [SerializeField] private TextMeshProUGUI _gemText;
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
        _gemText.text = gem.value.ToString();
        Destroy(gameObject);
    }
    #endregion
}
