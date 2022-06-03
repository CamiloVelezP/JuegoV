using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recoleccion1 : MonoBehaviour
{
    public inventario inventario; //llamar al script inventario
    // Start is called before the first frame update
    public Text cantidad;
    public Text textoValor;
    public GameObject imagenWin;
    public GameObject Jugador;
    public GameObject camara;
    public GameObject objetoTexto;
    public List<string> vectorValores;
    int numvalor;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Valor")
        {
            inventario.Cantidad = inventario.Cantidad + 1;// aumneta la cantidad 
            cantidad.text = "Cantidad = " + inventario.Cantidad;
            Destroy(other.gameObject);
            numvalor = Random.Range(0, vectorValores.Count);
            objetoTexto.SetActive(true);
            textoValor.text = "Has obtenido el valor: " + vectorValores[numvalor];
            Debug.Log(vectorValores[numvalor]);
            Invoke("mostrarValor", 2f);
            vectorValores.Remove(vectorValores[numvalor]);
            if (inventario.Cantidad == 1 )
            {
                Invoke("terminarPartida", 2f);
               
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
