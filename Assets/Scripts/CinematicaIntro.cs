using System.Collections;
using UnityEngine;

public class CinematicaIntro : MonoBehaviour
{
    [Header("UI del Juego")]
    public GameObject uiDecisiones;

    [Header("Personaje")]
    public Transform personajeTransform; // El Transform de Stickman
    public SpriteRenderer personajeSprite; // El SpriteRenderer de Stickman

    [Header("Posiciones de Movimiento")]
    public Vector3 posicionInicio = new Vector3(-8f, 0f, 0f); // Punto donde aparece afuera
    public Vector3 posicionFinal = new Vector3(0f, 0f, 0f);   // Punto donde se detiene

    [Header("Poses durante el recorrido")]
    public Sprite poseCaminarOMoverse;
    public Sprite poseFinalPensando;

    [Header("Ajustes de Velocidad")]
    public float duracionMovimiento = 1.5f; // Tiempo que tarda en desplazarse

    void Start()
    {
        if (uiDecisiones != null)
            uiDecisiones.SetActive(false);

        StartCoroutine(EjecutarCinematica());
    }

    IEnumerator EjecutarCinematica()
    {
        // 1. Ubicar al personaje en el punto inicial y poner pose de movimiento
        if (personajeTransform != null)
            personajeTransform.position = posicionInicio;

        if (personajeSprite != null && poseCaminarOMoverse != null)
            personajeSprite.sprite = poseCaminarOMoverse;

        // 2. Desplazar suavemente (interpolación) desde Inicio hasta Fin
        float tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < duracionMovimiento)
        {
            tiempoTranscurrido += Time.deltaTime;
            float porcentaje = tiempoTranscurrido / duracionMovimiento;

            // Transición fluida de posición
            personajeTransform.position = Vector3.Lerp(posicionInicio, posicionFinal, porcentaje);

            yield return null; // Espera al siguiente fotograma (60 FPS)
        }

        // Asegurar posición exacta al llegar
        personajeTransform.position = posicionFinal;

        // 3. Cambiar a la pose final (ej. pensando)
        if (personajeSprite != null && poseFinalPensando != null)
            personajeSprite.sprite = poseFinalPensando;

        yield return new WaitForSeconds(1.0f);

        // 4. Mostrar opciones
        if (uiDecisiones != null)
            uiDecisiones.SetActive(true);
    }
}