using UnityEngine;

namespace Arj2D
{
    public class AudioRandomPitch : MonoBehaviour
    {
        public AudioClip[] clips;
        public float pitchLower;
        public float pitchHigher;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.loop = false;
            }
        }

        public void Play()
        {
            audioSource.Stop();
            audioSource.clip = clips.RandomElement();
            audioSource.pitch = Random.Range(pitchLower, pitchHigher);
            audioSource.Play();
        }
    }
}


