using UnityEngine;
using UnityEngine.UI;

public class ManejadorVida : MonoBehaviour
{
    public static int Vidas = 3;
    public Image[] Corazones;
    public Jugador jugador;

    private void Start()
    {
        jugador = FindObjectOfType<Jugador>();
    }

    public void ChequeoVidas()
    {
        if(Vidas <= 0)
        {
            ReiniciarVidas();
            for (int i = 0; i < Corazones.Length; i++)
            {
                Corazones[i].enabled = true;
            }
            ManejadorJuego.Instancia.GameOver();
            enabled = false;
        }
    }

    public void ReducirVidas(){
        if(!jugador.invulnerable){
            Vidas--;
            Corazones[Vidas].enabled = false;
        }
    }

    public void ReiniciarVidas(){
        Vidas = 3;
    }

    public int ConsultarVidas(){
       return Vidas;
    }

    public void AumentarVidas(){
        if(Vidas < 3){
            Vidas++;
            Corazones[Vidas-1].enabled = true;
        }
    }
}
