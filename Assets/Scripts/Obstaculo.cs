using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private float bordeIzquierdo;

    private void Start()
    {
        bordeIzquierdo = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    private void Update()
    {
        transform.position += Vector3.left * ManejadorJuego.Instancia.velocidadJuego * Time.deltaTime;
        if(transform.position.x < bordeIzquierdo)
        {
            Destroy(gameObject);
        }
    }
}
