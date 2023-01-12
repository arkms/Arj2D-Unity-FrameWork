using UnityEngine;
using UnityEngine.Audio;

// This script should be manager by AudioSourcePool of AudioManager

public class AudioSourcePoolObject : MonoBehaviour
{

    AudioManager.AudioSourcePool container;
    [System.NonSerialized]
    public AudioSource audioSource;

    public void Play(AudioClip _clip, Vector3 _pos, float _pitch)
    {
        transform.localPosition = _pos;
        audioSource.clip = _clip;
        audioSource.pitch = _pitch;
        gameObject.SetActive(true);
        audioSource.Play();

        Invoke(nameof(Deactivate), _clip.length);
    }

    public void Init(AudioMixerGroup _group, AudioManager.AudioSourcePool _container, float _maxDistance)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.spatialBlend = 1f;
        audioSource.maxDistance = _maxDistance;
        audioSource.outputAudioMixerGroup = _group;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        gameObject.SetActive(false);
        container = _container;
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
        container.AddToPool(this);
    }
}
