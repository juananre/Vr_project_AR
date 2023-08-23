using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{
    [Header("Ferrer hizo esto")]
    //cambie agregue unas cosas en IncrementPressCount()
    [SerializeField] Image panelImage;


    [Header("Isa hizo esto")]

    private Transform botonTransform;
    private Renderer botonRenderer;
    private Color currentColor;
    private float colorChangeAmount = 0.5f; //Cantidad de cambio de color en cada clic
    private AudioSource pressSFX;

    public AudioClip pressSound; //Sonido de alarma, cada vez que se presiona
    public AudioClip suspenseSound; 
    public AudioClip horrorPianoSound;
    public AudioClip CinematicHitSound;
    public AudioClip TitleHitSound;
    
    private int pressCount = 0; //Variable para llevar el conteo de presiones

    public GameObject FloatingStuff1;
    public GameObject FloatingStuff2;
    public GameObject FloatingStuff3;
    public GameObject FloatingStuff4;

    public Canvas blackScreenCanvas;
    public RawImage ImageTitle;
    public float delayBeforeImageActivation = 2.0f;
    public float delayBeforeSoundActivation = 1.0f;

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
        

        if (pressCount == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(suspenseSound);
            FloatingStuff1.SetActive(true);

            Color panelcolor = panelImage.color;
            panelcolor.a = 0.2f;
            panelImage.color = panelcolor;
        }
        else if (pressCount == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(horrorPianoSound);
            FloatingStuff2.SetActive(true);

            Color panelcolor = panelImage.color;
            panelcolor.a = 0.3f;
            panelImage.color = panelcolor;
        }
        else if (pressCount == 3)
        {
            FloatingStuff3.SetActive(true);

            Color panelcolor = panelImage.color;
            panelcolor.a = 0.4f;
            panelImage.color = panelcolor;
        }
        else if (pressCount == 4)
        {
            FloatingStuff4.SetActive(true);
            Color panelcolor = panelImage.color;
            panelcolor.a = 0.5f;
            panelImage.color = panelcolor;
        }
        else if (pressCount == 5)
        {
            Color panelcolor = panelImage.color;
            panelcolor.a = 0.6f;
            panelImage.color = panelcolor;

            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(TitleHitSound);
            GetComponent<AudioSource>().PlayOneShot(CinematicHitSound);
            StartCoroutine(ActivateDelay());
            blackScreenCanvas.gameObject.SetActive(true);
            FloatingStuff3.SetActive(false);
            FloatingStuff2.SetActive(false);
            FloatingStuff1.SetActive(false);

        }
    }

    private IEnumerator ActivateDelay()
    {
        yield return new WaitForSeconds(delayBeforeImageActivation);
        ImageTitle.gameObject.SetActive(true);

    }

    private IEnumerator RestorePosition()
    {
        yield return new WaitForSeconds(0.2f);

        // Devolver el botón a su posición original
        Vector3 originalPosition = botonTransform.position + new Vector3(-0.1f, 0f, 0f);
        botonTransform.position = originalPosition;
    }
}
