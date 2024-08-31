using UnityEngine;

public class Powerup : MonoBehaviour
{
    protected float bordeIzquierdo;
    [SerializeField] protected AudioClip sonidoPowerup;

    protected void Start()
    {
        bordeIzquierdo = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    protected void Update()
    {
        transform.position += Vector3.left * ManejadorJuego.Instancia.velocidadJuego * Time.deltaTime;
        if(transform.position.x < bordeIzquierdo)
        {
            Destroy(gameObject);
        }
    }

    public virtual void ActivarEfecto(){}
}
