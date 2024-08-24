using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour
{
    private CharacterController personaje;
    private ManejadorVida manejadorVida;
    private Vector3 direccion;
    public float gravedad = 9.81f * 2f;
    public float fuerzaSalto = 8f;
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
                direccion = Vector3.up * fuerzaSalto;
            }
        }

        personaje.Move(direccion * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider otro)
    {
        if(otro.CompareTag("Obstaculo"))
        {
            manejadorVida.ReducirVidas();
            if(manejadorVida.ConsultarVidas() > 0){
                StartCoroutine(Lastimarse());
                ManejadorJuego.Instancia.ReducirVelocidadJuego();
            }
        }
    }

    IEnumerator Lastimarse()
    {
        Physics.IgnoreLayerCollision(6,8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics.IgnoreLayerCollision(6,8,false);
    }
    
}
