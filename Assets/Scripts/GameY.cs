using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameY : MonoBehaviour
{
    public void Play()
    {
        // Carga la escena del juego
        SceneManager.LoadScene("Game Y");
    }
}
