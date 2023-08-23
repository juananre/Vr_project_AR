using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    private Transform botonTransform;
    private Renderer botonRenderer;
    private Color currentColor;
    private float colorChangeAmount = 0.5f; //Cantidad de cambio de color en cada clic
    private AudioSource pressSFX;

    public AudioClip pressSound; //Sonido de alarma, cada vez que se presiona
    public AudioClip suspenseSound; 
    public AudioClip horrorPianoSound; 

    private int pressCount = 0; // Variable para llevar el conteo de presiones

    private void Awake()
    {
        botonTransform = GetComponent<Transform>();
        botonRenderer = GetComponent<Renderer>();
        currentColor = botonRenderer.material.color;
        pressSFX = GetComponent<AudioSource>();

       
    }

    private void OnMouseDown()
    {
        IncrementPressCount();

        pressSFX.Play();
        // Bajar el botón en el eje Z
        Vector3 newPosition = botonTransform.position - new Vector3(-0.1f, 0f, 0f);
        botonTransform.position = newPosition;

        // Cambiar gradualmente el color a rojo
        currentColor += new Color(colorChangeAmount, 0, 0);
        botonRenderer.material.color = currentColor;

        GetComponent<AudioSource>().PlayOneShot(pressSound);

        StartCoroutine(RestorePosition());
    }

    private void IncrementPressCount()
    {
        pressCount++; // Incrementar el conteo de presiones
        Debug.Log("Presionado " + pressCount + " veces.");

        if (pressCount == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(suspenseSound);
            
        }
        else if (pressCount == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(horrorPianoSound);
        }
        else if (pressCount == 3)
        {
            // Acción específica para la tercera vez
            Debug.Log("Acción de la tercera vez.");
        }
    }

    private IEnumerator RestorePosition()
    {
        yield return new WaitForSeconds(0.2f);

        // Devolver el botón a su posición original
        Vector3 originalPosition = botonTransform.position + new Vector3(-0.1f, 0f, 0f);
        botonTransform.position = originalPosition;
    }
}
