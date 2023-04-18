using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuOpciones;

    private static MenuManager _instance;
    public static MenuManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // El objeto MenuManager persiste entre escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe un MenuManager en la escena, destruir el nuevo objeto
        }
    }

    public void AbrirMenuOpciones()
    {
        Time.timeScale = 0f; // Pausamos el juego
        menuOpciones.SetActive(true);
    }

    public void CerrarMenuOpciones()
    {
        Time.timeScale = 1f; // Reanudamos el juego
        menuOpciones.SetActive(false);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CargarMenuDeOpciones()
    {
        SceneManager.LoadScene("NombreDeLaEscenaDelMenuDeOpciones");
    }
}
