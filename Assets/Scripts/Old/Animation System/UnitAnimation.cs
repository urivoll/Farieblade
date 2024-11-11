using Core.InGame.Controller;
using Core.InGame.Utils;
using Cysharp.Threading.Tasks;
using Events;
using Spine;
using Spine.Unity;
using UnityEngine;
using Zenject;

public class UnitAnimation : EventBehaviour
{
    [Inject] private SoundController _soundController;
    [Inject] private GameSpeed _gameSpeed;

    [SerializeField] private AnimationReferenceAsset _attack, _idle, _hit, _death, _spell, _spell2, _spell3, _aura, _mode, _passive;
    [SerializeField] private AudioClip[] _attackSound;
    [SerializeField] private AudioClip[] _voiceHitSound;
    [SerializeField] private AudioClip[] _voiceAttackSound;
    [SerializeField] private AudioClip[] _swishSound;
    [SerializeField] private AudioClip _voiceDeathSound;
    [SerializeField] private int _swishDelay;
    [SerializeField] private int _attackDelay;

    private SkeletonAnimation _skeletonAnimation;
    private TrackEntry animationEntry = null;

    public void Open(SkeletonAnimation skeletonAnimation)
    {
        _skeletonAnimation = skeletonAnimation;
    }

    public void AttackSound()
    {
        if (_voiceAttackSound.Length > 0) _soundController.PlayRandomSound(_attackSound);
    }

    private async void AnimationDelay(int delay, string type)
    {
        int speed = _gameSpeed.GetGameSpeed();
        await UniTask.Delay((_attackDelay - _swishDelay) / speed);
        if (_voiceAttackSound.Length > 0) _soundController.PlayRandomVoice(_voiceAttackSound);
        if (_swishSound.Length > 0) _soundController.PlayRandomSound(_swishSound);
        await UniTask.Delay(_swishDelay / speed);
        DispatchEvent(type);
    }

    public void SetCaracterState(string state)
    {
        if (state.Equals("idle")) SetAnimation(_idle, true);
        else if (state.Equals("attack"))
        {
            SetAnimation(_attack, false);
            AnimationDelay(_attackDelay, "attack");
        }
        else if (state.Equals("hit"))
        {
            _soundController.PlayRandomVoice(_voiceHitSound);
            SetAnimation(_hit, false);
        }
        else if (state.Equals("spell")) SetAnimation(_spell, false);
        else if (state.Equals("spell2")) SetAnimation(_spell2, false);
        else if (state.Equals("spell3")) SetAnimation(_spell3, false);
        else if (state.Equals("aura")) SetAnimation(_aura, false);
        else if (state.Equals("mode")) SetAnimation(_mode, false);
        else if (state.Equals("passive")) SetAnimation(_passive, false);
    }

    public async void DeathAnimation()
    {
        int speed = _gameSpeed.GetGameSpeed();
        if (animationEntry != null) animationEntry.Complete -= AnimationEntry_Complete;
        animationEntry = _skeletonAnimation.state.SetAnimation(0, _death, false);
        animationEntry.TimeScale = speed;
        if (_voiceDeathSound != null) _soundController.PlayVoice(_voiceDeathSound);
        else _soundController.PlayRandomVoice(_voiceHitSound);
        await UniTask.Delay(500 / speed);
        if (gameObject != null) _soundController.PlayRegularSound(0);
    }

    private void AnimationEntry_Complete(TrackEntry trackEntry)
    {
        SetCaracterState("idle");
    }

    //Установка анимации персонажа
    public void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        int speed = _gameSpeed.GetGameSpeed();
        if (animationEntry != null) animationEntry.Complete -= AnimationEntry_Complete;
        animationEntry = _skeletonAnimation.state.SetAnimation(0, animation, loop);
        animationEntry.TimeScale = speed;
        animationEntry.Complete += AnimationEntry_Complete;
    }
}
