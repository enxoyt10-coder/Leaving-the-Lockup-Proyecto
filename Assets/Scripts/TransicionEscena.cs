using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransicionEscena : MonoBehaviour
{
    [Header("Configuración de la Pantalla")]
    public Image panelFade;
    public float duracionFade = 1f; // Tiempo que tarda en oscurecerse

    public void IrAEscena(string nombreEscena)
    {
        StartCoroutine(RutinaFade(nombreEscena));
    }

    IEnumerator RutinaFade(string nombreEscena)
    {
        float tiempo = 0f;
        Color colorFondo = panelFade.color;

        // Aseguramos que comience totalmente transparente
        colorFondo.a = 0f;
        panelFade.color = colorFondo;
        panelFade.raycastTarget = true;

        // Bucle para oscurecer la pantalla gradualmente
        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            colorFondo.a = Mathf.Clamp01(tiempo / duracionFade);
            panelFade.color = colorFondo;
            yield return null;
        }

        // Asegurar que quede completamente negro antes de cambiar
        colorFondo.a = 1f;
        panelFade.color = colorFondo;

        // Breve pausa para que se alcance a ver el negro completo
        yield return new WaitForSeconds(0.2f);

        // Cambia de escena
        SceneManager.LoadScene(nombreEscena);
    }
}