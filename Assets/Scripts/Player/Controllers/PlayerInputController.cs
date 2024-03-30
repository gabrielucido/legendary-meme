using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputController : PlayerController
{
    [Header("Actions asset")] public InputActionAsset playerControls;

    [Header("Action map name reference")] private const string ActionMapKey = "Player";

    [Header("Action name reference")] 
    private const string AimActionKey = "Aim";
    private const string MoveActionKey = "Move";
    private const string AttackActionKey = "Attack";

    [Header("Actions bindings")]
    private InputAction _aimAction;
    private InputAction _moveAction;
    private InputAction _attackAction;


    private void OnEnable()
    {
        _aimAction.Enable();
        _moveAction.Enable();
        _attackAction.Enable();
    }

    private void OnDisable()
    {
        _aimAction.Disable();
        _moveAction.Disable();
        _attackAction.Disable();
    }

    protected override void Awake()
    {
        base.Awake();
        _aimAction = playerControls.FindActionMap(ActionMapKey).FindAction(AimActionKey);
        _moveAction = playerControls.FindActionMap(ActionMapKey).FindAction(MoveActionKey);
        _attackAction = playerControls.FindActionMap(ActionMapKey).FindAction(AttackActionKey);
        GatherAimInput();
        GatherMovementInput();
        GatherAttackInput();
    }

    private void GatherAimInput()
    {
        _aimAction.performed += ctx => manager.aimDirection = ctx.ReadValue<Vector2>();
        _aimAction.canceled += ctx => manager.aimDirection = Vector2.zero;
    }

    private void GatherMovementInput()
    {
        _moveAction.performed += ctx => manager.moveDirection = ctx.ReadValue<Vector2>();
        _moveAction.canceled += ctx => manager.moveDirection = Vector2.zero;
    }

    private void GatherAttackInput()
    {
        _attackAction.performed += ctx => manager.attackPressed = true;
        _attackAction.canceled += ctx => manager.attackPressed = false;
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