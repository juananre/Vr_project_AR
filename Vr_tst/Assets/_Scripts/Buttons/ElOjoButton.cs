using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElOjoButton : MonoBehaviour
{
    public GameObject ElOjo;
    public GameObject GrupoOjos;
    public GameObject Hueco2;
    private void OnMouseDown()
    {
        ElOjo.SetActive(false);
        GrupoOjos.SetActive(true);
        Hueco2.SetActive(true);
    }
}
