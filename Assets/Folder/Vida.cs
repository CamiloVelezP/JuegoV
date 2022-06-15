using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public Transform puntoReaparicion;
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemigo")){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            transform.position = puntoReaparicion.position;

        }
    }
}
