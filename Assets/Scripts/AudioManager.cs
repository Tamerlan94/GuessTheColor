
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public AudioClip[] clips;
    private int index = -1;
    public AudioSource source;
    

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (!source.isPlaying)
        {
            index++;
            if (index == clips.Length)
            {
                index = 0;
            }
            source.clip = clips[index];
            source.Play();
        }
    }
    public void NextMusic()
    {
        source.Stop();
        index++;
        if (index == clips.Length)
        {
            index = 0;
        }
        source.clip = clips[index];
        source.Play();
    }
    public void PlaySfx(AudioClip audio)
    {
        source.PlayOneShot(audio);
    }
}
