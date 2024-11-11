using JetBrains.Annotations;
using UnityEngine;

namespace Core.InGame.Model
{
    public class SoundModel : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _voiceSource;
        [SerializeField] private AudioClip[] _regularSound;
        [SerializeField] private AudioClip[] _soundClicks;

        public void PlaySound(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }

        public void PlayVoice(AudioClip audioClip)
        {
            _voiceSource.PlayOneShot(audioClip);
        }

        public void PlayRegularSound(int index)
        {
            _audioSource.PlayOneShot(_regularSound[index]);
        }

        public void PlayClickSound(int index)
        {
            _audioSource.PlayOneShot(_soundClicks[index]);
        }
    }
}
