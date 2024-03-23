using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputController : PlayerController
{
    [Header("Actions asset")] public InputActionAsset playerControls;

    [Header("Action map name reference")] private const string ActionMapKey = "Player";

    [Header("Action name reference")] private const string AimActionKey = "Aim";
    private const string MoveActionKey = "Move";

    [Header("Actions bindings")] private InputAction _aimAction;
    private InputAction _moveAction;


    private void OnEnable()
    {
        _aimAction.Enable();
        _moveAction.Enable();
    }

    private void OnDisable()
    {
        _aimAction.Disable();
        _moveAction.Disable();
    }

    protected override void Awake()
    {
        base.Awake();
        _aimAction = playerControls.FindActionMap(ActionMapKey).FindAction(AimActionKey);
        _moveAction = playerControls.FindActionMap(ActionMapKey).FindAction(MoveActionKey);
        GatherAimInput();
        GatherMovementInput();
    }

    private void GatherAimInput()
    {
        _aimAction.performed += ctx => player.aimDirection = ctx.ReadValue<Vector2>();
        _aimAction.canceled += ctx => player.aimDirection = Vector2.zero;
    }

    private void GatherMovementInput()
    {
        _moveAction.performed += ctx => player.moveDirection = ctx.ReadValue<Vector2>();
        _moveAction.canceled += ctx => player.moveDirection = Vector2.zero;
    }


    #region Validation

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (playerControls == null)
        {
            Debug.LogError("Please assign a Player Data asset to the Player Manager data slot", this);
        }
    }
#endif

    #endregion
}