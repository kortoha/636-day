using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const string BOOL_NAME = "IsRun";

    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private float _turnSpeed = 200;

    [SerializeField] private Animator _animator;

    private PlayerInput _input;
    private Rigidbody _rigidBody;
    private bool _isMoving;
    private Vector2 _moveInput;
    private Vector3 _worldMoveDirection;
    private bool _isStickHeld;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _input = new PlayerInput();

        _input.Player.Enable();

        _input.Player.Move.performed += ctx =>
        {
            _moveInput = ctx.ReadValue<Vector2>();
            _isStickHeld = true;
        };
        _input.Player.Move.canceled += ctx =>
        {
            _moveInput = Vector2.zero;
            _isStickHeld = false;
            _worldMoveDirection = Vector3.zero; // Сбрасываем направление движения при отпускании стика
        };

        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveCharacter(_moveInput);
        UpdateAnimator();
    }

    private void MoveCharacter(Vector2 moveInput)
    {
        Transform cameraTransform = Camera.main.transform;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;

        if (_isStickHeld && moveDirection != Vector3.zero)
        {
            _worldMoveDirection = moveDirection; // Сохраняем направление движения в мировых координатах
        }

        Vector3 targetVelocity = _worldMoveDirection * _moveSpeed;
        Vector3 velocityChange = targetVelocity - _rigidBody.velocity;

        velocityChange.y = 0;
        _rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);

        // Убираем вращение персонажа
        if (_worldMoveDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(_worldMoveDirection);
            _rigidBody.MoveRotation(rotation);
        }
    }

    private void UpdateAnimator()
    {
        _isMoving = _moveInput.magnitude > 0.1f;
        _animator.SetBool(BOOL_NAME, _isMoving);
    }
}