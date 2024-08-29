
using UnityEngine;

public class ManejadorSFX : MonoBehaviour
{
    public static ManejadorSFX Instancia {get; private set;}

    [SerializeField] private AudioSource objetoSFX;

    public void Awake()
    {
        if(Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instancia == this)
        {
            Instancia = null;
        }
    }

    public void ReproducirSFX(AudioClip audioClip)
    {
        AudioSource audioSource = Instantiate(objetoSFX);

        audioSource.clip = audioClip;

        audioSource.Play();

        float duracion = audioSource.clip.length;

        Destroy(audioSource.gameObject, duracion);
    }
}
