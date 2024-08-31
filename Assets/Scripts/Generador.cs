using Unity.VisualScripting;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [System.Serializable]
    public struct ObjetoGenerable
    {
        public GameObject prefabricable;
        [Range(0f, 1f)]
        public float chanceGenerar;
    }

    public ObjetoGenerable[] obstaculos;
    public ObjetoGenerable[] powerups;
    public ObjetoGenerable[] decoraciones;
    private bool genero = false;
    

    public float indiceMinGenerador = 1f;
    public float indiceMaxGeneradorObstaculo = 2f;
    public float indiceMaxGeneradorPowerup = 3f;
    public float indiceMinGeneradorDecoracion = 10f;
    public float indiceMaxGeneradorDecoracion = 12f;

    private void OnEnable()
    {
        Invoke(nameof(GenerarObstaculo), Random.Range(indiceMinGenerador, indiceMaxGeneradorObstaculo));
        Invoke(nameof(GenerarPowerup), Random.Range(indiceMinGenerador, indiceMaxGeneradorPowerup));
        Invoke(nameof(GenerarDecoracion), Random.Range(indiceMinGeneradorDecoracion, indiceMaxGeneradorDecoracion));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void GenerarObstaculo()
    {
        float chanceGenerarObstaculo = Random.value;

        foreach (var obj in obstaculos)
        {
            if(chanceGenerarObstaculo < obj.chanceGenerar)
            {
                GameObject obstaculo = Instantiate(obj.prefabricable);
                obstaculo.transform.position += transform.position;
                genero = true;
                break;
            }
            chanceGenerarObstaculo -= obj.chanceGenerar;
        }

        Invoke(nameof(GenerarObstaculo), Random.Range(indiceMinGenerador, indiceMaxGeneradorObstaculo));
    }

    private void GenerarPowerup()
    {
        float chanceGenerarPowerup = Random.value;

        foreach (var obj in powerups)
        {
            if(chanceGenerarPowerup < obj.chanceGenerar)
            {
                GameObject powerup = Instantiate(obj.prefabricable);
                powerup.transform.position += transform.position;
                if(genero)
                {
                    powerup.transform.position += transform.position + Vector3.up * 1.5f;
                    genero = false;
                }
                break;
            }
            chanceGenerarPowerup -= obj.chanceGenerar;
        }

        Invoke(nameof(GenerarPowerup), Random.Range(indiceMinGenerador, indiceMaxGeneradorPowerup));
    }

    private void GenerarDecoracion()
    {
        float chanceGenerarDecoracion = Random.value;

        foreach (var obj in decoraciones)
        {
            if(chanceGenerarDecoracion < obj.chanceGenerar)
            {
                float ubicacion = Random.Range(3f, 5f);
                GameObject decoracion = Instantiate(obj.prefabricable);
                decoracion.transform.position += transform.position + Vector3.up * ubicacion;
                break;
            }
            chanceGenerarDecoracion -= obj.chanceGenerar;
        }

        Invoke(nameof(GenerarDecoracion), Random.Range(indiceMinGeneradorDecoracion, indiceMaxGeneradorDecoracion));
    }
}