using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject pausaBtn;
    
    public void Awake()
    {
        menuPausa.SetActive(false);
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        pausaBtn.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Continuar()
    {
        menuPausa.SetActive(false);
        pausaBtn.SetActive(true);
        Time.timeScale = 1f;
    }
}
