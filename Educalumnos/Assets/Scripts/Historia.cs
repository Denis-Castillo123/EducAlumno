using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Historia : MonoBehaviour
{
    public void Omitir(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Siguiente(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Volver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    

    
}
