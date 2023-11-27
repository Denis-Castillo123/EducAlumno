using UnityEngine;

public class SountrackInicio : MonoBehaviour
{
    public static SountrackInicio instance;
    public AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el objeto se destruya al cambiar de escena.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }
}
