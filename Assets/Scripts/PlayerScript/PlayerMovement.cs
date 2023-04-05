using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Expose
    [Header("Movement Parameters")]
    [SerializeField] private int _walkSpeed;
    [SerializeField] private int _sprintSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    [Space]
    [Header("Floor Detection")]
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Vector3 _boxDimension;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _yFloorOfset;
    [Space]
    [Header("Slope handling")]
    [SerializeField] private float _maxSlopeAngle;
    #endregion

    #region Unity Life Cycle
    void Start()
    {
        _cameraTransform = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
        _floorDetector = GetComponentInChildren<FloorDetection>();
    }

    void Update()
    {
        Move();
        Jump();
        Collider[] groundColliders = Physics.OverlapBox(_groundChecker.position, _boxDimension, Quaternion.identity, _groundMask);
        _isGrounded = groundColliders.Length > 0;
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
        {
            StickToGround();
            if (_isJumping)
            {
                _isGrounded = false;
                _direction.y = _jumpForce;
                _isJumping = false;
            }
        }
        else
        {
            _direction.y = _rigidbody.velocity.y;
        }
        if (SlopeAngle() > _maxSlopeAngle)
        {
            Vector3 localDirection = transform.InverseTransformDirection(_direction);   //Passe du gloabal au local
            if (localDirection.z > 0) localDirection.z = 0;   //Pas le droit d'avancer
            _direction = transform.TransformDirection(localDirection);  //Repasse la direction en global
        }
        _rigidbody.velocity = _direction;
        RotateTowardsCamera();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundChecker.position, _boxDimension * 2f);
    }
    #endregion

    #region methods
    private void Move()
    {
        _direction = _cameraTransform.right * Input.GetAxis("Horizontal") + _cameraTransform.forward * Input.GetAxis("Vertical");
        _direction *= _walkSpeed;
        _animator.SetFloat("speedX", _direction.x);
        _animator.SetFloat("speedZ", _direction.z);
        if (Input.GetButton("Sprint"))
        {
            Sprint();
        }
    }

    private void Sprint()
    {
        _direction = _cameraTransform.right * Input.GetAxis("Horizontal") + _cameraTransform.forward * Input.GetAxis("Vertical");
        _direction *= _sprintSpeed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
        }
    }

    private void RotateTowardsCamera()
    {
        if (_direction.magnitude > 0.1f)
        {
            Vector3 cameraForward = _cameraTransform.forward;
            cameraForward.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(cameraForward);
            _rigidbody.MoveRotation(lookRotation);
        }
    }

    private void StickToGround()
    {
        Vector3 averagePosition = _floorDetector.AverageHeight();
        Vector3 newPosition = new Vector3(_rigidbody.position.x, averagePosition.y + _yFloorOfset, _rigidbody.position.z);
        _rigidbody.MovePosition(newPosition);
    }

    private float SlopeAngle()
    {
        Vector3 startingpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        Debug.DrawRay(startingpoint, Vector3.down);
        if (Physics.Raycast(startingpoint, Vector3.down, out _slopeHit))
        {
            float angle = Vector3.Angle(Vector3.up, _slopeHit.normal);
            return angle;
        }
        return 370;
    }
    #endregion

    #region Private & Protected
    private Vector3 _direction = new Vector3();
    private Transform _cameraTransform;
    private Rigidbody _rigidbody;
    private FloorDetection _floorDetector;
    private RaycastHit _slopeHit;
    public bool _isJumping = false;
    public bool _isGrounded = true;
    #endregion
}
