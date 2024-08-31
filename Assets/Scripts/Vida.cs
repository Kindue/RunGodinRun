using UnityEngine;

public class Vida : Powerup
{
    private ManejadorVida manejadorVida;

    protected new void Start()
    {
        manejadorVida = FindObjectOfType<ManejadorVida>();
        bordeIzquierdo = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    public override void ActivarEfecto()
    {
        if(manejadorVida.ConsultarVidas() < 3)
        {
            ManejadorSFX.Instancia.ReproducirSFX(sonidoPowerup);
            Destroy(gameObject);
        }
        manejadorVida.AumentarVidas();
    }
}
