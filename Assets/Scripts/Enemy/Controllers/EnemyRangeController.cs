using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeController : EnemyController
{
    private void OnTriggerEnter(Collider other)
    {
        var trigger = other.gameObject?.GetComponentInParent<IPlayer>();
        
        if (trigger != null)
        {
            Debug.Log(trigger);
        }
    }
}