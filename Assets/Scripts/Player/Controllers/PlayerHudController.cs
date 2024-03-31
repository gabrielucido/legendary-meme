using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class PlayerHudController : PlayerController
{
    [SerializeField] private UIDocument hud;

    private void Start()
    {
        if (hud == null)
        {
            Debug.LogError("HUD reference not set in PlayerHudController.");
        }
    }

    private void Update()
    {
        var healthBar = hud.rootVisualElement.Q<ProgressBar>("HealthBar");

        if (healthBar != null)
        {
            healthBar.value = manager.healthPoints;
            healthBar.highValue = manager.data.maxHealthPoints;
        }
        else
        {
            Debug.LogError("Can't find HealthBar in HUD.");
        }
    }
}