using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer mixer;

    public Sound[] sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = FindSound(name);
        if (sound != null)
        {
            sound.source.Play();
        }
    }

    public void StopSound(string name)
    {
        Sound sound = FindSound(name);
        if (sound != null)
        {
            sound.source.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
    }

    private Sound FindSound(string name)
    {
        Sound sound = System.Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found in sounds array.");
        }
        return sound;
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
