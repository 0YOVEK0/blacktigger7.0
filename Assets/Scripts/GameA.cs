using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameA : MonoBehaviour
{
    public void Play()
    {
        // Carga la escena del juego
        SceneManager.LoadScene("GameA");
    }
}
