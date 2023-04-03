using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour
{
    #region Expose
    [SerializeField] private int _damage;
    [SerializeField] private TrapType _type;
    [SerializeField] private Collider _sphereCollider;
    [SerializeField] private GameObject _lockCollider;
    #endregion

    #region Unity Life Cycle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (_type) 
            { 
                case TrapType.Lava: 
                    break;
                case TrapType.Rock:
                    _lockCollider.SetActive(false);
                    _sphereCollider.isTrigger = true;
                    RockTrap(); 
                    break;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (_type)
            {
                case TrapType.Lava:
                    break;
                case TrapType.Rock:
                    Destroy(_sphereCollider.gameObject); 
                    break;
            }
        }
    }
    #endregion

    #region methods
    private void RockTrap()
    {
        if (_sphereCollider.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.DecreaseHealth(_damage);
        }
    }
    #endregion
}
public enum TrapType
{
    Lava,
    Rock
}
