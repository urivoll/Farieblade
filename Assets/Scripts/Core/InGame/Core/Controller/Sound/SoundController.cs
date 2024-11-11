using Core.InGame.Model;
using UnityEngine;
using Zenject;
using EventDispatcher = Events.EventDispatcher;

namespace Core.InGame.Controller
{
    public class SoundController : EventDispatcher
    {
        [Inject] private SoundModel _soundModel;

        public void PlaySound(AudioClip audioClip)
        {
            _soundModel.PlaySound(audioClip);
        }

        public void PlayVoice(AudioClip audioClip)
        {
            _soundModel.PlayVoice(audioClip);
        }

        public void PlayRandomSound(AudioClip[] audioClip)
        {
            PlaySound(audioClip[Random.Range(0, audioClip.Length)]);
        }

        public void PlayRandomVoice(AudioClip[] audioClip)
        {
            PlayVoice(audioClip[Random.Range(0, audioClip.Length)]);
        }

        public void PlayRegularSound(int index)
        {
            _soundModel.PlayRegularSound(index);
        }

        public void PlayClickSound(int index)
        {
            _soundModel.PlayClickSound(index);
        }
    }
}
