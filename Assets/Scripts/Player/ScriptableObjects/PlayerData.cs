using UnityEngine;

[CreateAssetMenu]
public class PlayerData : CharacterData
{
    [Header("Aim")] 
    [Tooltip("The aim sensitivity of the player")]
    public float aimSensitivity = 10;
    //
    // [Tooltip("The player's acceleration")]
    // public float acceleration = 120;
    //
    // [Tooltip("The pace at which the player comes to a stop")]
    // public float groundDeceleration = 60;
    //
    // [Tooltip("Deceleration in air only after stopping input mid-air")]
    // public float airDeceleration = 30;
    //
    // [Tooltip("A constant downward force applied while grounded. Helps on slopes"), Range(0f, -10f)]
    // public float groundingForce = -1.5f;
    //
    // [Tooltip("The detection distance for grounding and roof detection"), Range(0f, 0.5f)]
    // public float grounderDistance = 0.05f;
    //
    // [Header("Jump")] [Tooltip("The immediate velocity applied when jumping")]
    // public float jumpPower = 36;
    //
    // [Tooltip("The maximum vertical movement speed")]
    // public float maxFallSpeed = 40;
    //
    // [Tooltip("The player's capacity to gain fall speed. a.k.a. In Air Gravity")]
    // public float fallAcceleration = 110;
    //
    // [Tooltip("The gravity multiplier added when jump is released early")]
    // public float jumpEndEarlyGravityModifier = 3;
    //
    // [Tooltip(
    //     "The time before coyote jump becomes unusable. Coyote jump allows jump to execute even after leaving a ledge")]
    // public float coyoteTime = .15f;
    //
    // [Tooltip("The amount of time we buffer a jump. This allows jump input before actually hitting the ground")]
    // public float jumpBuffer = .2f;
    //
    // [Header("Input")]
    // [Tooltip(
    //     "Makes all Input snap to an integer. Prevents gamepads from walking slowly. Recommended value is true to ensure gamepad/keybaord parity.")]
    // public bool snapInput = true;
    //
    // [Tooltip(
    //      "Minimum input required before you mount a ladder or climb a ledge. Avoids unwanted climbing using controllers"),
    //  Range(0.01f, 0.99f)]
    // public float verticalDeadZoneThreshold = 0.3f;
    //
    // [Tooltip("Minimum input required before a left or right is recognized. Avoids drifting with sticky controllers"),
    //  Range(0.01f, 0.99f)]
    // public float horizontalDeadZoneThreshold = 0.1f;
}