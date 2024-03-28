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
        _rotationX -= player.aimDirection.y * player.data.aimSensitivity * Time.deltaTime *
                      defaultSensitivityMultiplier;
        player.rotationY += player.aimDirection.x * player.data.aimSensitivity * Time.deltaTime *
                            defaultSensitivityMultiplier;
        _rotationX = Mathf.Clamp(_rotationX, -90, 90);
        player.cameraFollowTarget.transform.rotation = Quaternion.Euler(_rotationX, player.rotationY, 0);
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