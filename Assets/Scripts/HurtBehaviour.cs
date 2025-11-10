using UnityEngine;
using System;

public class HurtBehaviour : MonoBehaviour
{
    
    public LayerMask targetLayers;

    
    public static event Action<GameObject> OnPlayerHurt;

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (((1 << other.gameObject.layer) & targetLayers.value) == 0)
            return;

       
        OnPlayerHurt?.Invoke(other.gameObject);
    }
}