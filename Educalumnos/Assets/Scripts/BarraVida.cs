using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        InicializarBarraVida(100); 
    }

public void CambiarVidaMaxima(float vidaMaxima)
{
    if (slider != null)
    {
        slider.maxValue = vidaMaxima;
    }
    else
    {
        Debug.LogError("El componente Slider es null en BarraVida.");
    }
}

public void CambiarVidaActual(float cantidadVida)
{
    if (slider != null)
    {
        slider.value = cantidadVida;
    }
    else
    {
        Debug.LogError("El componente Slider es null en BarraVida.");
    }
}


    public void InicializarBarraVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
