using UnityEngine;

public class bgmusiccontrol : MonoBehaviour
{
    public AudioClip bgaudio;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        playbgmusic();
    }

    public void playbgmusic()
    {
        if (!player_control.playerdead)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = bgaudio;
                audioSource.Play();
            }
        }
        if (player_control.playerdead)
        {
            audioSource.Stop();
        }
    }
}