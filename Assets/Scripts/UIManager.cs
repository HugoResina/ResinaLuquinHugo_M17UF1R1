using UnityEngine;
using UnityEngine.SceneManagement; 

public class UIController : MonoBehaviour
{
    public GameObject pantallaInicio;
    public GameObject menuPausa;
    private bool juegoPausado = false;

    void Start()
    {
        pantallaInicio.SetActive(true);
        menuPausa.SetActive(false);
        Time.timeScale = 0f; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                ContinuarJuego();
            else
                PausarJuego();
        }
    }

    public void IniciarJuego()
    {
        pantallaInicio.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void PausarJuego()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void ContinuarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Salir juego"); 
    }
}