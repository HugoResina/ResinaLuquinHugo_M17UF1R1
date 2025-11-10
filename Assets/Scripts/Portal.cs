using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform destination;

    private void OnTriggerEnter2D(Collider2D other)
    {

        other.transform.position = destination.position;
        Player player = other.GetComponent<Player>();
        player.RespawnPoint = destination;
    }
}
