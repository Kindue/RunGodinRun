public class Puntos : Powerup
{
    private int cantidadPuntos = 200;

    public override void ActivarEfecto()
    {
        ManejadorSFX.Instancia.ReproducirSFX(sonidoPowerup);
        ManejadorJuego.Instancia.AumentarPuntos(cantidadPuntos);
        Destroy(gameObject);
    }
}
