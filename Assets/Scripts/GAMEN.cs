using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEN : MonoBehaviour
{
    public void Play()
    {
        // Carga la escena del juego
        SceneManager.LoadScene("GameN");
    }
}
