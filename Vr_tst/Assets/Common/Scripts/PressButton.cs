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

    // ... Otros métodos del script ...

    private void OnMouseDown()
    {
        // Bajar el botón en el eje Y
        Vector3 newPosition = botonTransform.position - new Vector3(-0.1f, 0f, 0f); // Cambia el valor 0.1f según tus necesidades
        botonTransform.position = newPosition;

        // Cambiar gradualmente el color a rojo
        currentColor += new Color(colorChangeAmount, 0, 0);
        botonRenderer.material.color = currentColor;

        // Lanzar una corrutina para devolver el botón a su posición original después de un tiempo
        StartCoroutine(RestorePosition());
    }

    private IEnumerator RestorePosition()
    {
        yield return new WaitForSeconds(0.2f); // Esperar un tiempo breve (ajusta el valor según tus necesidades)

        // Devolver el botón a su posición original
        Vector3 originalPosition = botonTransform.position + new Vector3(-0.1f, 0f, 0f); // Cambia el valor 0.1f según tus necesidades
        botonTransform.position = originalPosition;
    }
}
