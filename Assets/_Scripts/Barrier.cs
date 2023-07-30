using System;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    /// <summary>
    /// Reset bullet, reset camera, set aiming true, following false. 
    /// </summary>
    public static event Action OnLeftArea;

    private void OnTriggerEnter(Collider other)
    {
        OnLeftArea?.Invoke();
    }
}