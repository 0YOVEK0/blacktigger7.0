using UnityEngine;
using UnityEngine.UI;

public class ControlOpciones : MonoBehaviour
{
    public Slider sliderSonido;
    public Slider sliderFxSonido;
    public Dropdown dropdownIdioma;
    public Dropdown dropdownResolucion;

    void Start()
    {
        sliderSonido.value = PlayerPrefs.GetFloat("VolumenSonido", 1f);
        sliderFxSonido.value = PlayerPrefs.GetFloat("VolumenFxSonido", 1f);
        dropdownIdioma.value = PlayerPrefs.GetInt("Idioma", 0);
        dropdownResolucion.value = PlayerPrefs.GetInt("Resolucion", 0);
    }

    public void CambiarSonido()
    {
        AudioListener.volume = sliderSonido.value;
        PlayerPrefs.SetFloat("VolumenSonido", sliderSonido.value);
    }

    public void CambiarFxSonido()
    {
        // Aquí debes cambiar los efectos de sonido en tu juego
        PlayerPrefs.SetFloat("VolumenFxSonido", sliderFxSonido.value);
    }

    public void CambiarIdioma()
    {
        // Aquí debes cambiar el idioma en tu juego
        PlayerPrefs.SetInt("Idioma", dropdownIdioma.value);
    }

    public void CambiarResolucion()
    {
        switch (dropdownResolucion.value)
        {
            case 0:
                Screen.SetResolution(800, 600, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1024, 768, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
        }
        PlayerPrefs.SetInt("Resolucion", dropdownResolucion.value);
    }
}
