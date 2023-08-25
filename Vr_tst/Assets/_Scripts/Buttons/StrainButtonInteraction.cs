using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrainButtonInteraction : MonoBehaviour
{
    private void OnMouseDown()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1ImD9CtbW0Erty7X7iHJpLZkznGfqJK2c?usp=drive_link");
        //Destroy(gameObject, 2f);
        //gameObject.SetActive(false);
    }
}
