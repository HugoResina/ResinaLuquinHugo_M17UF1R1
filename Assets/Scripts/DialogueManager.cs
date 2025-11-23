using UnityEngine;
using UnityEngine.UI;

public class MostrarTextoAlColisionar : MonoBehaviour
{
    public Text textoCanvas; 
    private Collider2D colliderObjetivo; 
    public string mensajeInicial;
    public string ultimoMensaje ;
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
            
            textoCanvas.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (textoActivo && Input.GetKeyDown(KeyCode.E))
        {
            if (!mostrandoUltimoMensaje)
            {
               
                textoCanvas.text = ultimoMensaje;
                mostrandoUltimoMensaje = true;
            }
            else
            {
              
                if (colliderObjetivo != null)
                    colliderObjetivo.enabled = false;
                textoCanvas.gameObject.SetActive(false);
                textoActivo = false;
            }
        }
    }
}