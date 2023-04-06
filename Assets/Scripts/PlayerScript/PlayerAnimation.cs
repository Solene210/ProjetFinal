using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Expose
    [SerializeField] private Animator _animator;
    #endregion

    #region Unity Life Cycle
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentSpeed = 0;
    }

    void Update()
    {
        _currentSpeed = _rb.velocity.magnitude;
        if (_currentSpeed < 0.5f)
        {
            IsIdle = true;
            _currentSpeed = 0;
        }
        else
        {
            IsIdle = false;
        }
        AnimationToPlay();
    }
    #endregion

    #region methods
    private void AnimationToPlay()
    {
        _animator.SetFloat("moveSpeed", _currentSpeed);
    }
    #endregion

    #region Private & Protected
    public bool IsIdle { get => _isIdle; set => _isIdle = value; }
    private Rigidbody _rb;
    private float _currentSpeed;
    private bool _isIdle = true;
    #endregion
}
