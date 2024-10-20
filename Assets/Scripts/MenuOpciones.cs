using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Volumen()
    {

    }
}
