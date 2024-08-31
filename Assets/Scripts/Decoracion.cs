using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoracion : MonoBehaviour
{
    private float bordeIzquierdo;
    private ManejadorFondo manejadorFondo;

    private void Start()
    {
        bordeIzquierdo = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        manejadorFondo = FindObjectOfType<ManejadorFondo>();
    }
    private void Update()
    {
        transform.position += Vector3.left * (manejadorFondo.ConsultarVelocidad()+ 0.5f) * Time.deltaTime;
        if(transform.position.x < bordeIzquierdo)
        {
            Destroy(gameObject);
        }
    }
}
