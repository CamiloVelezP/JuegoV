using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recoleccion1 : MonoBehaviour
{
    public int cantidadToWin = 6;
    public float timeToWin = 8f;
    public inventario inventario; //llamar al script inventario
    // Start is called before the first frame update
    public Text cantidad;
    public Text textoValor;
    public GameObject imagenWin;
    public GameObject Jugador;
    public GameObject camara;
    public GameObject objetoTexto;
    public GameObject NPCMaletin;
    public GameObject gemaHonesta;
    public GameObject triggerHonesto;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Valor")
        {
            inventario.Cantidad = inventario.Cantidad + 1;// aumneta la cantidad 
            cantidad.text = "Valores = " + inventario.Cantidad;
            Destroy(other.gameObject);
            if (inventario.Cantidad >= cantidadToWin)
            {
                Invoke("terminarPartida", timeToWin);

            }
        }
        if (other.tag == "Maletin")
        {
            inventario.recogioMaletin = true;
            Destroy(other.gameObject);
            textoValor.text = "Este maletín se le debió perder a alguien, puedo buscar por las casas.";
            objetoTexto.SetActive(true);
            Invoke("mostrarValor", 4f);
            NPCMaletin.SetActive(true);

        }
        if (other.tag == "NPCMaletin" && inventario.recogioMaletin == true)
        {
            inventario.entregoMaletin = true;
            inventario.recogioMaletin = false;
            textoValor.text = "Gracias por devolver mi maletín, ahi tengo mi trabajo de grado";
            objetoTexto.SetActive(true);
            gemaHonesta.SetActive(true);
            triggerHonesto.SetActive(true);
            Invoke("mostrarValor", 3f);
            if (inventario.Cantidad >= cantidadToWin)
            {
                Invoke("terminarPartida", timeToWin);

            }

        }


    }
    private void mostrarValor()
    {
        objetoTexto.SetActive(false);
    }
    private void terminarPartida()
    {
        imagenWin.SetActive(true);
        camara.SetActive(true);
        cantidad.enabled = false;
        Jugador.SetActive(false);
    }
}
