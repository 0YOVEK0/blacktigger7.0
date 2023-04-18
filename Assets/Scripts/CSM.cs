using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSM : MonoBehaviour
{
    public void Play()
    {
        // Carga la escena del juego
        SceneManager.LoadScene("Game");
    }
}
