using UnityEngine;

public class Jugador : MonoBehaviour
{
    private CharacterController personaje;
    private Vector3 direccion;
    public float gravedad = 9.81f * 2f;
    public float fuerzaSalto = 8f;
    private void Awake()
    {
        personaje = GetComponent<CharacterController>();
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
            ManejadorJuego.Instancia.GameOver();
        }
    }
}
