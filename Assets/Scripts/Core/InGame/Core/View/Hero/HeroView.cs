using Core.InGame.Utils;
using Events;
using Spine.Unity;
using UnityEngine;

namespace Core.InGame.View
{
    public class HeroView : EventBehaviour
    {
        private UnitAnimation _animation;

        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private Vector2 _bulletPosition;
        [SerializeField] private Vector2 _uiPosition;
        [SerializeField] private ClickView _clickView;

        public Vector2 UiPosition => _uiPosition;

        public void Open()
        {
            _bulletPosition = transform.TransformPoint(_bulletPosition);
            //_weapon = GetComponent<IWeapon>();
            _animation = _skeletonAnimation.GetComponent<UnitAnimation>();
            _animation.Open(_skeletonAnimation);
            _clickView.AddListener("Удар", HandlerClickEvent);
            _animation.AddListener("attack", AttackAnimation);
        }

        public void Close()
        {
            _clickView.RemoveListener("Удар", HandlerClickEvent);
            _animation.RemoveListener("attack", AttackAnimation);
            _animation.DeathAnimation();
            Destroy(gameObject, 1f);
        }

        public void Attack()
        {
            //_weapon.Attack();
        }

        private void HandlerClickEvent(EventArgs evt)
        {
            DispatchEvent("Удар");
        }

        public void SetPosition(CirclePosition circlePosition, TurnSide turnSide)
        {
            transform.position = circlePosition.Position;
            _skeletonAnimation.GetComponent<SkeletonPartsRenderer>().MeshRenderer.sortingOrder = circlePosition.SortingOrder;
            int side = 1;
            if (turnSide == TurnSide.left) side = -1;
            _skeletonAnimation.transform.localScale = new Vector2(circlePosition.Size.x * side, circlePosition.Size.y);
        }

        public void MoveOver(char sign)
        {
            float x;
            if (sign == '-') x = _skeletonAnimation.transform.position.x - 2;
            else x = _skeletonAnimation.transform.position.x + 2;
            _skeletonAnimation.transform.position = new Vector2(x, _skeletonAnimation.transform.position.y);
        }

        public void PlayAttackSound()
        {
            _animation.AttackSound();
        }

        public void PlayAnimation(string state)
        {
            _animation.SetCaracterState(state);
        }

        private void AttackAnimation(EventArgs evt)
        {
            DispatchEvent("attack");
        }
    }
}