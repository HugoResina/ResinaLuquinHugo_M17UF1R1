using UnityEngine;
using System;

public class SawSoundEnabler : MonoBehaviour
{
    private bool activado = false;
    public static event Action OnPermitirDispararChanged;
    public static event Action OnAllowSawSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activado)
        {
            OnPermitirDispararChanged?.Invoke();
            OnAllowSawSound?.Invoke();
            activado = true;
        }
    }
}