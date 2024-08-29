using UnityEngine;

public class Invulnerabilidad : Powerup
{
    private Jugador jugador;
    private float duracion = 10f;

    protected new void Start()
    {
        jugador = FindObjectOfType<Jugador>();
        bordeIzquierdo = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    public override void ActivarEfecto()
    {
        if(!jugador.invulnerable){
            jugador.invulnerable = true;
            Destroy(gameObject);
            jugador.InvulnerabilidadAux(duracion);
        }
    }
}
