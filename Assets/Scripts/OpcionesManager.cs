using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OpcionesManager : MonoBehaviour
{
    public AudioMixer mezcladorAudio;
    public Dropdown dropdownIdiomas;
    public Toggle toggleSonido;
    public Toggle toggleFXSonido;
    public Dropdown dropdownResoluciones;

    private int[] anchosResoluciones = { 640, 800, 1024, 1280, 1366, 1440, 1600, 1920 };
    private int[] altosResoluciones = { 480, 600, 768, 720, 768, 900, 1200, 1080 };

    private void Start()
    {
        // Inicializar los valores de las opciones
        InicializarIdiomas();
        InicializarSonido();
        InicializarFXSonido();
        InicializarResoluciones();
    }

    public void EstablecerVolumenMaestro(float volumen)
    {
        mezcladorAudio.SetFloat("VolumenMaestro", volumen);
    }

    public void EstablecerVolumenMusica(float volumen)
    {
        mezcladorAudio.SetFloat("VolumenMusica", volumen);
    }

    public void EstablecerVolumenFX(float volumen)
    {
        mezcladorAudio.SetFloat("VolumenFX", volumen);
    }

    public void CambiarIdioma(int indice)
    {
        // Aquí puedes implementar el cambio de idioma en tu juego
    }

    public void ActivarSonido(bool activar)
    {
        AudioListener.volume = activar ? 1f : 0f;
    }

    public void ActivarFXSonido(bool activar)
    {
        // Aquí puedes implementar la activación/desactivación de los efectos de sonido en tu juego
    }

    public void CambiarResolucion(int indice)
    {
        if (indice >= 0 && indice < anchosResoluciones.Length && indice < altosResoluciones.Length)
        {
            Screen.SetResolution(anchosResoluciones[indice], altosResoluciones[indice], Screen.fullScreen);
        }
    }

    private void InicializarIdiomas()
    {
        // Aquí puedes inicializar las opciones del dropdown de idiomas
        // Puedes obtener las opciones de un archivo de configuración o de una base de datos, por ejemplo
    }

    private void InicializarSonido()
    {
        bool activado = AudioListener.volume == 1f;
        toggleSonido.isOn = activado;
    }

    private void InicializarFXSonido()
    {
        // Aquí puedes inicializar la opción del toggle de efectos de sonido
        // Puedes obtener el estado de una preferencia guardada en PlayerPrefs, por ejemplo
    }

   private void InicializarResoluciones()
   {
    dropdownResoluciones.ClearOptions();

    for (int i = 0; i < anchosResoluciones.Length; i++)
    {
        string opcion = anchosResoluciones[i] + " x " + altosResoluciones[i];
        dropdownResoluciones.options.Add(new Dropdown.OptionData(opcion));
    }

    // Obtener la resolución actual y seleccionarla en el dropdown
    int ancho = Screen.currentResolution.width;
    int alto = Screen.currentResolution.height;
    int indice = -1;

    for (int i = 0; i < anchosResoluciones.Length; i++)
    {
        if (ancho == anchosResoluciones[i] && alto == altosResoluciones[i])
        {
            indice = i;
            break;
        }
    }

    if (indice >= 0)
    {
        dropdownResoluciones.value = indice;
    }
}

}
