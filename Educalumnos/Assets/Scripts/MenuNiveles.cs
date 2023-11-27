using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public void Nivel1(){
        SceneManager.LoadScene("Nivel_1");
    }

    public void Nivel2(){
        SceneManager.LoadScene("Nivel_2");
    }

    public void Nivel3(){
        SceneManager.LoadScene("Nive_3");
    }

    public void Volver(){
        SceneManager.LoadScene("MenuInicial");
    }

}
