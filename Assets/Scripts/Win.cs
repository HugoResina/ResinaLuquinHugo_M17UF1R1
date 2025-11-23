using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] private GameObject panelVictoria;
    public LayerMask player;

    private void Start()
    {
        panelVictoria.SetActive(false); 
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("Victoria");
            panelVictoria.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

   
  
}