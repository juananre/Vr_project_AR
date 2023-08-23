using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    private Transform botonTransform;
    private Renderer botonRenderer;
    private Color currentColor;
    private float colorChangeAmount = 0.5f; // Cantidad de cambio de color en cada clic

    private void Awake()
    {
        botonTransform = GetComponent<Transform>();
        botonRenderer = GetComponent<Renderer>();
        currentColor = botonRenderer.material.color;
    }

    // ... Otros m�todos del script ...

    private void OnMouseDown()
    {
        // Bajar el bot�n en el eje Y
        Vector3 newPosition = botonTransform.position - new Vector3(-0.1f, 0f, 0f); // Cambia el valor 0.1f seg�n tus necesidades
        botonTransform.position = newPosition;

        // Cambiar gradualmente el color a rojo
        currentColor += new Color(colorChangeAmount, 0, 0);
        botonRenderer.material.color = currentColor;

        // Lanzar una corrutina para devolver el bot�n a su posici�n original despu�s de un tiempo
        StartCoroutine(RestorePosition());
    }

    private IEnumerator RestorePosition()
    {
        yield return new WaitForSeconds(0.2f); // Esperar un tiempo breve (ajusta el valor seg�n tus necesidades)

        // Devolver el bot�n a su posici�n original
        Vector3 originalPosition = botonTransform.position + new Vector3(-0.1f, 0f, 0f); // Cambia el valor 0.1f seg�n tus necesidades
        botonTransform.position = originalPosition;
    }
}
