using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaManoButton : MonoBehaviour
{
    public GameObject LaMano;
    public GameObject GrupoManos;
    public GameObject Hueco3;
    private void OnMouseDown()
    {
        //Activar
        LaMano.SetActive(false);
        Hueco3.SetActive(true);

        //Desactivar
        GrupoManos.SetActive(true);
        
    }
}
