using UnityEngine;
using UnityEngine.UI;

public class MostrarTextoAlColisionar : MonoBehaviour
{
    public Text textoCanvas; // Texto UI en Canvas
    private Collider2D colliderObjetivo; // Collider 2D a desactivar
    public string mensajeInicial = "Has colisionado con el objeto";
    public string ultimoMensaje = "Último mensaje";
    private bool textoActivo = false;
    private bool mostrandoUltimoMensaje = false;
    public LayerMask playerLayer;

    void Start()
    {
        textoCanvas.gameObject.SetActive(false);
        colliderObjetivo = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            if (!textoActivo)
            {
                textoCanvas.text = mensajeInicial;
                mostrandoUltimoMensaje = false;
                textoActivo = true;
            }
            // Mostrar texto dependiendo del estado actual (mensaje inicial o último)
            textoCanvas.gameObject.SetActive(true);
            if (mostrandoUltimoMensaje)
                textoCanvas.text = ultimoMensaje;
            else
                textoCanvas.text = mensajeInicial;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            // Al salir del trigger solo ocultar texto pero mantener el estado para reanudar diálogo
            textoCanvas.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (textoActivo && Input.GetKeyDown(KeyCode.E))
        {
            if (!mostrandoUltimoMensaje)
            {
                // Mostrar el último mensaje
                textoCanvas.text = ultimoMensaje;
                mostrandoUltimoMensaje = true;
            }
            else
            {
                // Diálogo terminado, desactivar collider y ocultar texto
                if (colliderObjetivo != null)
                    colliderObjetivo.enabled = false;
                textoCanvas.gameObject.SetActive(false);
                textoActivo = false;
            }
        }
    }
}