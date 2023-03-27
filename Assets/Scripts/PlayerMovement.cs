using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Expose
    [Header("Movement Parameters")]
    [SerializeField] private int _walkSpeed;
    #endregion

    #region Unity Life Cycle
    private void Awake()
    {
        
    }

    void Start()
    {
        _cameraTransform = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Walk();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction;
        RotateTowardsCamera();
    }
    #endregion

    #region methods
    private void Walk()
    {
        _direction = _cameraTransform.right * Input.GetAxis("Horizontal") + _cameraTransform.forward * Input.GetAxis("Vertical");
        _direction *= _walkSpeed;
    }

    private void RotateTowardsCamera()
    {
        if (_direction.magnitude > 0.1f)
        {
            Vector3 cameraForward = _cameraTransform.forward;
            cameraForward.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(cameraForward);
            //Quaternion rotation = Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, _turnSpeed * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(lookRotation);
        }
    }
    #endregion

    #region Private & Protected
    private Vector3 _direction = new Vector3();
    private Transform _cameraTransform;
    private Rigidbody _rigidbody;
    #endregion
}
