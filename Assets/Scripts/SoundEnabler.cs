using UnityEngine;
using System;

public class SoundEnabler : MonoBehaviour
{
    private bool activado = false;
    public static event Action OnPermitirDispararChanged;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activado)
        {
            OnPermitirDispararChanged?.Invoke();
            activado = true;
        }
    }
}