using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    public Light directionalLight;
    public float minIntensity = 0.8f;
    public float maxIntensity = 2.0f;
    public float intensityChangeRate = 0.4f;

    private float currentIntensity;

    private void Awake()
    {
        currentIntensity = directionalLight.intensity; // Inicializar con la intensidad actual de la luz
    }

    private void OnMouseDown()
    {
        ChangeLightIntensity();
    }

    private void ChangeLightIntensity()
    {
        currentIntensity += intensityChangeRate; //Incrementar la intensidad actual
        currentIntensity = Mathf.Clamp(currentIntensity, minIntensity, maxIntensity); //Asegurar que esté dentro de los límites

        directionalLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, currentIntensity); //Cambiar la intensidad gradualmente
    }
}
