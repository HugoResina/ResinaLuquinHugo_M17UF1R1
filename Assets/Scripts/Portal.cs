using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private SawPathFollower saw;

    
    [SerializeField] private AudioSource sonidoAMutear;
    [SerializeField] private AudioSource sonidoAActivar;

 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            other.transform.position = destination.position;
            Player player = other.GetComponent<Player>();
            player.RespawnPoint = destination;
            saw.Restart();

          
            if (sonidoAMutear != null && sonidoAMutear.isPlaying)
            {
                sonidoAMutear.mute = true;
            }

            
            if (sonidoAActivar != null)
            {
                sonidoAActivar.mute = false;
            }
        }
    }
}