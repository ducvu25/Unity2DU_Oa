using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum EffectAudio
{
    run1,
    run2,
    open
}

public class AudioController : MonoBehaviour
{
    [Header("effect")]
    [SerializeField] AudioClip[] effects;
    AudioSource[] adoSEffects;

    [SerializeField] GameObject prefab;

    // Start is called before the first frame update
    public static AudioController instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        adoSEffects = new AudioSource[effects.Length];
    }
    public void Play(int i)
    {
        Play(effects[i], ref adoSEffects[i], 0.5f, false, false);
    }
    public void Stop(int i)
    {
        if (adoSEffects[i] != null)
            Destroy(adoSEffects[i].gameObject);
    }
    public void PlaySound(int i, float volume = 0.5f, bool isLoopback = false, bool repeat = false)
    {
        Play(effects[i],ref adoSEffects[i], volume, isLoopback, repeat);
    }
    void Play(AudioClip clip, ref AudioSource audioSource, float volume = 1f, bool isLoopback = false, bool repeat = false)
    {
        if (audioSource != null && audioSource.isPlaying && !repeat)
            return;
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();
        audioSource.volume = volume;
        audioSource.loop = isLoopback;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
