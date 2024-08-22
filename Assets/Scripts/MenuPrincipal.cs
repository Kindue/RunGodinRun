using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void IrMenuOpciones()
    {
        SceneManager.LoadScene("MenuOpciones");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
