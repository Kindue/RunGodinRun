public class Puntos : Powerup
{
    private int cantidadPuntos = 200;

    public override void ActivarEfecto()
    {
        ManejadorJuego.Instancia.AumentarPuntos(cantidadPuntos);
        Destroy(gameObject);
    }
}
