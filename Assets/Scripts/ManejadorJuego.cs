using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManejadorJuego : MonoBehaviour
{
    //Patron de diseño Singleton
    public static ManejadorJuego Instancia {get; private set;}
    
    public float velocidadJuegoInicial = 5f;
    public float velocidadJuegoIncremento = 0.1f;
    public float velocidadJuego {get; private set;}

    public TextMeshProUGUI gameOverTexto;
    public Button botonReintentar;
    public Button botonVolver;
    public TextMeshProUGUI puntajeTexto;
    public TextMeshProUGUI puntajeAltoTexto;
    
    private Jugador jugador;
    private Generador generador;

    private float puntaje;


    private void Awake()
    {
        if(Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instancia == this)
        {
            Instancia = null;
        }
    }

    private void Start()
    {
        jugador = FindObjectOfType<Jugador>();
        generador = FindObjectOfType<Generador>();
        NuevoJuego();
    }

    public void NuevoJuego()
    {
        Obstaculo[] obstaculos = FindObjectsOfType<Obstaculo>();

        foreach(var obstaculo in obstaculos)
        {
            Destroy(obstaculo.gameObject);
        }

        puntaje = 0f;
        velocidadJuego = velocidadJuegoInicial;
        enabled = true;

        jugador.gameObject.SetActive(true);
        generador.gameObject.SetActive(true);

        gameOverTexto.gameObject.SetActive(false);
        botonReintentar.gameObject.SetActive(false);
        botonVolver.gameObject.SetActive(false);

        ActualizarPuntajeAlto();

    }

     public void GameOver()
     {
        velocidadJuego = 0f;
        enabled = false;
        jugador.gameObject.SetActive(false);
        generador.gameObject.SetActive(false);

        gameOverTexto.gameObject.SetActive(true);
        botonReintentar.gameObject.SetActive(true);
        botonVolver.gameObject.SetActive(true);

        ActualizarPuntajeAlto();


     }
     
    private void Update()
    {
        velocidadJuego += velocidadJuegoIncremento * Time.deltaTime;
        puntaje += velocidadJuego * Time.deltaTime;
        puntajeTexto.text = Mathf.FloorToInt(puntaje).ToString("D5");
    }

    public void ActualizarPuntajeAlto()
    {
        float puntajeAlto = PlayerPrefs.GetFloat("puntajeAlto", 0);
        if(puntaje > puntajeAlto)
        {
            puntajeAlto = puntaje;
            PlayerPrefs.SetFloat("puntajeAlto", puntajeAlto);
        }

        puntajeAltoTexto.text = Mathf.FloorToInt(puntajeAlto).ToString("D5");
    }

}
