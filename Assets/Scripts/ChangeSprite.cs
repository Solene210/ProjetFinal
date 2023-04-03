using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    #region Expose
    [SerializeField] private Image _crystal;
    [SerializeField] private Sprite _crystalEmpty;
    [SerializeField] private Sprite _crystalColor;
    #endregion

    #region Unity Life Cycle
    void Start()
    {
        _crystal.sprite = _crystalEmpty;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _crystal.sprite = _crystalColor;
        }
    }
    #endregion
}
