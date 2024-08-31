using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour
{
    private CharacterController personaje;
    private ManejadorVida manejadorVida;
    private Vector3 direccion;
    public float gravedad = 9.81f * 2f;
    public float fuerzaSalto = 8f;
    public bool invulnerable = false;
    [SerializeField] private AudioClip sonidoSalto;
    [SerializeField] private AudioClip sonidoColision;
    private void Awake()
    {
        personaje = GetComponent<CharacterController>();
        manejadorVida = FindObjectOfType<ManejadorVida>();
    }

    private void OnEnable()
    {
        direccion = Vector3.zero;
    }


    private void Update()
    {
        direccion += Vector3.down * gravedad * Time.deltaTime;

        if(personaje.isGrounded)
        {
            direccion = Vector3.down;
            if(Input.GetButton("Jump") || Input.touchCount > 0)
            {
                ManejadorSFX.Instancia.ReproducirSFX(sonidoSalto);
                direccion = Vector3.up * fuerzaSalto;
            }
        }

        personaje.Move(direccion * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider otro)
    {
        if(otro.CompareTag("Obstaculo"))
        {
            if(!invulnerable){
                ManejadorSFX.Instancia.ReproducirSFX(sonidoColision);
                manejadorVida.ReducirVidas();
                if(manejadorVida.ConsultarVidas() > 0){
                    StartCoroutine(Invulnerabilidad(3f));
                    ManejadorJuego.Instancia.ReducirVelocidadJuego();
                }
            }
        }
        if(otro.CompareTag("Powerup"))
        {
            otro.GetComponent<Powerup>().ActivarEfecto();
        }
    }

    public void InvulnerabilidadAux(float cant)
    {
        StartCoroutine(Invulnerabilidad(cant));
    }

    public IEnumerator Invulnerabilidad(float cant)
    {
        Physics.IgnoreLayerCollision(8,9);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(cant);
        invulnerable = false;
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics.IgnoreLayerCollision(8,9,false);
    }
    
}
