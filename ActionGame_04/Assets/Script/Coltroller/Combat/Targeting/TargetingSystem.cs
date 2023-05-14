using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public event Action<TargetingSystem> OnDestroyed;

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

}
