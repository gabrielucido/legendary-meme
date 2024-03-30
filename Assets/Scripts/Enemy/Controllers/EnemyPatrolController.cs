using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class EnemyPatrolController : PlayerController
{
    
        

    #region Validation

#if UNITY_EDITOR
    private void OnValidate()
    {
        // if (playerControls == null)
        // {
        //     Debug.LogError("Please assign a Player Data asset to the Player Manager data slot", this);
        // }
    }
#endif

    #endregion
}