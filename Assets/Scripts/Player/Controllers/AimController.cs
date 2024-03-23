using UnityEngine;

public class AimController : PlayerController
{
    private void Update()
    {
        LockCursor();
        HandleAim();
    }

    private void HandleAim()
    {
        if (player.aimDirection.magnitude > 0.1f)
        {
            Debug.Log(player.aimDirection);
            player.cameraFollowTarget.transform.Rotate(
                player.aimDirection * (player.data.aimSensitivity * Time.deltaTime * 50f));
        }
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
}