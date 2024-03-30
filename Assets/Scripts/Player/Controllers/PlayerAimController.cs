using System;
using UnityEngine;

public class PlayerAimController : PlayerController
{
    private float _rotationX;
    public static readonly float defaultSensitivityMultiplier = 50;

    private void Update()
    {
        LockCursor();
        HandleAim();
    }

    private void HandleAim()
    {
        _rotationX -= manager.aimDirection.y * manager.data.aimSensitivity * Time.deltaTime *
                      defaultSensitivityMultiplier;
        manager.rotationY += manager.aimDirection.x * manager.data.aimSensitivity * Time.deltaTime *
                            defaultSensitivityMultiplier;
        _rotationX = Mathf.Clamp(_rotationX, -90, 90);
        manager.cameraFollowTarget.transform.rotation = Quaternion.Euler(_rotationX, manager.rotationY, 0);
    }

    private static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnEnable()
    {
        LockCursor();
    }

    private void OnDisable()
    {
        UnlockCursor();
    }
}