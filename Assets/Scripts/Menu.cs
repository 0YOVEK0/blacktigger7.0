using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    public void Play()
    {
        // Carga la escena del juego
        SceneManager.LoadScene("CS");
    }

    public void Settings()
    {
        // Carga la escena de configuraciones
        SceneManager.LoadScene("MenuOpciones");
    }

    public void Quit()
    {
        // Sale de la aplicación
        Application.Quit();
    }
}