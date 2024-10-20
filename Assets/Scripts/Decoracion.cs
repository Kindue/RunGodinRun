using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoracion : MonoBehaviour
{
    private float bordeIzquierdo;
    private ManejadorFondo manejadorFondo;
    private float indiceVelocidadFondo;
    private float vJuego;

    private void Start()
    {
        bordeIzquierdo = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        manejadorFondo = FindObjectOfType<ManejadorFondo>();
        indiceVelocidadFondo = manejadorFondo.ConsultarIndiceVelocidad();

    }
    private void Update()
    {
        vJuego = ManejadorJuego.Instancia.velocidadJuego;
        if(vJuego > 0)
        {
            transform.position += Vector3.left * ((vJuego / indiceVelocidadFondo)+ 0.5f) * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * (vJuego / indiceVelocidadFondo) * Time.deltaTime;

        }
        if(transform.position.x < bordeIzquierdo)
        {
            Destroy(gameObject);
        }
    }
}
