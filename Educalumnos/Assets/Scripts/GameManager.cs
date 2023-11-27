using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TMP_InputField playerNameInput;
    public MongoDBManager mongoDBManager;

    public void SetPlayerName()
    {
        string playerName = playerNameInput.text;
        mongoDBManager.RegistrarJugador(playerName);
        SceneManager.LoadScene("MenuNiveles");
    }

    public void Volver(){
        SceneManager.LoadScene("MenuInicial");
    }
}
