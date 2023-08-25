using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaBocaButton : MonoBehaviour
{
    public GameObject LaBoca;
    public GameObject GrupoBocas;
    public GameObject GrupoOjosss;
    public GameObject Enunciado;
    public GameObject GrupoFinal;
    private void OnMouseDown()
    {
        //Activar
        GrupoBocas.SetActive(true);
        Enunciado.SetActive(true);
        GrupoFinal.SetActive(true);
        GrupoOjosss.SetActive(true);


        //Desactivar
        LaBoca.SetActive(false);
        
        
    }
}
