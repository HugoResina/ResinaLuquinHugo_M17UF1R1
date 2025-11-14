using UnityEngine;
using System;

public class HurtBehaviour : MonoBehaviour
{
    
    public LayerMask targetLayers;

    
    public static event Action<GameObject> OnPlayerHurt;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (((1 << other.gameObject.layer) & targetLayers.value) == 0)
            return;

       
        OnPlayerHurt?.Invoke(other.gameObject);
    
    }
}