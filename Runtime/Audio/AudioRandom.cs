using UnityEngine;

namespace Arj2D
{
    public class AudioRandom : MonoBehaviour
    {
        public AudioClip[] clips;

        public void Play()
        {
            AudioManager.Play(clips.RandomElement());
        }
    }
}
