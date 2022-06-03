using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemigo")){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
