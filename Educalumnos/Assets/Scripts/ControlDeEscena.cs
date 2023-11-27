using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeEscena : MonoBehaviour
{
    public float duracionEscenaActual = 2f;

    void Start()
    {
        Invoke("CargarSiguienteEscena", duracionEscenaActual);
    }

    void CargarSiguienteEscena()
    {
        // Carga la siguiente escena.
        SceneManager.LoadScene("Historia_P1");
    }
}

