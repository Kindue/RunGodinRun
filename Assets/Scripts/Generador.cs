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

    public ObjetoGenerable[] objetos;

    public float indiceMinGenerador = 1f;
    public float indiceMaxGenerador = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Generar), Random.Range(indiceMinGenerador, indiceMaxGenerador));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Generar()
    {
        float chanceGenerar = Random.value;

        foreach (var obj in objetos)
        {
            if(chanceGenerar < obj.chanceGenerar)
            {
                GameObject obstaculo = Instantiate(obj.prefabricable);
                obstaculo.transform.position += transform.position;
                break;
            }
            chanceGenerar -= obj.chanceGenerar;
        }

        Invoke(nameof(Generar), Random.Range(indiceMinGenerador, indiceMaxGenerador));
    }
}
