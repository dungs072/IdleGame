using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerController))]
public class PlayerController : MonoBehaviour
{
    [Header("Model player")]
    [SerializeField] private Transform playerModel;
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10f;
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 3f;
    [Header("Force receiver")]
    [SerializeField] private ForceReceiver forceReceiver;
    [Header("Animator")]
    [SerializeField] private PlayerAnimator playerAnimator;
    private PlayerInput playerInput;
    private CharacterController characterController;
    private Vector3 previousDirection;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        UpdateMovement();
        UpdateLookDirection();
        UpdateAnimator();
    }

    private void UpdateMovement()
    {
        Vector2 movement = playerInput.MovementValue;
        Vector3 movementValue = new Vector3(movement.x, 0, movement.y) * movementSpeed * Time.deltaTime +
                                forceReceiver.Movement;

        characterController.Move(movementValue);

    }
    private void UpdateLookDirection()
    {
        Vector2 movement = playerInput.MovementValue;
        Vector3 direction = default;
        if (movement == Vector2.zero)
        {
            direction = previousDirection;
        }
        else
        {
            direction = new Vector3(movement.x, 0, movement.y);
            previousDirection = direction;
        }

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        playerModel.rotation = Quaternion.Slerp(playerModel.rotation,
                            lookRotation, rotationSpeed * Time.deltaTime);
    }
    private void UpdateAnimator()
    {
        Vector2 movement = playerInput.MovementValue;
        playerAnimator.SetLocomotionValue(movement==Vector2.zero?0:1);
    }
    public void AddSpeed(float amount)
    {
        movementSpeed += amount;
    }
}
