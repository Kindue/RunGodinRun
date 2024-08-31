using UnityEngine;

public class ManejadorFondo : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float indiceVelocidadFondo;
    private float velocidad;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        velocidad = ManejadorJuego.Instancia.velocidadJuego / indiceVelocidadFondo;
        meshRenderer.material.mainTextureOffset += Vector2.right * velocidad * Time.deltaTime;
    }

    public float ConsultarVelocidad()
    {
        return velocidad;
    }
}
