using Core.InGame.DTO;
using Core.InGame.Model;
using Core.InGame.Spells;
using Core.InGame.Utils;
using Core.InGame.View;
using Cysharp.Threading.Tasks;
using Events;
using UnityEngine;
using Zenject;
using EventDispatcher = Events.EventDispatcher;

namespace Core.InGame.Controller
{
    public class HeroController : EventDispatcher
    {
        [Inject] private UnitCoordinatorController _unitCoordinatorController;
        [Inject] private CirclesController _circlesController;
        [Inject] private TurnController _turnController;
        [Inject] private PlayerController _playerController;
        [Inject] private GameSpeed _gameSpeed;

        private HeroModel _heroModel;
        private HeroView _heroView;
        private HeroUI _heroUi;
        private HeroDTO _heroDTO = null;
        private HeroSpells _heroSpells;

        public void Open(
            HeroView heroView, 
            HeroModel heroModel, 
            HeroUI heroUI)
        {
            _heroModel = heroModel;
            _heroView = heroView;
            _heroUi = heroUI;
            _heroView.Open();
            _heroView.AddListener("Удар", HandlerHitEvent);
            _heroView.AddListener("attack", AttackAnimationBack);
            _circlesController.AddListener("Change view", ChangeView);
            _heroUi.Open((int)_heroModel.HeroDto.Hp, (int)_heroModel.HeroDto.Damage);
            _turnController.AddListener("Change turn", NewTurn);
            EventArgs evt = new EventArgs("new");
            ChangeView(evt);
            _heroSpells.Open(_heroModel.HeroDto);
        }

        public void Close()
        {
            _unitCoordinatorController.KillHero(_heroModel.HeroDto.Position, _heroModel.HeroDto.TurnSide);
            _heroView.RemoveListener("Удар", HandlerHitEvent);
            _heroView.RemoveListener("attack", AttackAnimationBack);
            _circlesController.RemoveListener("Change view", ChangeView);
            _turnController.RemoveListener("Change turn", NewTurn);
            _heroView.Close();
            _heroUi.OnDestroy();
            _turnController.KillHero(_heroModel.HeroDto);
        }

        public void SetCurrentSpell(int index = 0)
        {
            _heroSpells.ChooseSpell(index);
        }

        private void ChangeView(EventArgs evt)
        {
            CirclePosition circlePosition = _circlesController.GetCirclePosition(_heroModel.Position, _heroModel.TurnSide);
            SetPosition(circlePosition);
        }

        public HeroDTO GetHeroProperties()
        {
            return _heroModel.HeroDto;
        }

        public void SetPosition(CirclePosition position)
        {
            _heroView.SetPosition(position, _heroModel.TurnSide);
            _heroUi.SetPosition(_heroView.UiPosition, _heroView.transform);
        }

        public void Attack(HeroDTO attackedHero)
        {

            _heroView.Attack();
            _heroModel.SetAttackedHero(attackedHero);
        }

        public void MoveOver()
        {
            char sign = (_heroModel.TurnSide == TurnSide.left) ? '-' : '+';
            _heroView.MoveOver(sign);
        }

        public void MoveOverBack()
        {
            char sign = (_heroModel.TurnSide == TurnSide.left) ? '+' : '-';
            _heroView.MoveOver(sign);
        }

        private async void AttackAnimationBack(EventArgs evt)
        {
            int speed = _gameSpeed.GetGameSpeed();
            if (_heroModel.AttackedHero == null) return;
            if (_heroModel.CheckHit())
            {
                _heroModel.AttackedHero.HeroController.TakeDamage(_heroModel.HeroDto.Damage);
                _heroView.PlayAttackSound();
            }
            _heroModel.RemoveAttackedHero();
            await UniTask.Delay(400 / speed);

            _turnController.EndStep();
        }

        public void TakeDamage(float damage)
        {
            HeroUI_takeDamageDTO data = _heroModel.TakeDamage(damage);
            if (data.Hp <= 0)
            {
                Close();
                return;
            }
            _heroView.PlayAnimation("hit");
            _heroUi.ChangeUIData(data);
        }

        private void HandlerHitEvent(EventArgs evt)
        {
            TurnSide mySide = _playerController.GetMySide();
            TryToUseSpell(mySide);
        }

        public void TryToUseSpell(TurnSide turnSide)
        {
            if (!_turnController.CheckIsYourTurn(turnSide))
            {
                Debug.Log("Не твой ход!");
                return;
            }
            if (!_unitCoordinatorController.TryToAttack(_heroModel.Position, _heroModel.HeroDto.TurnSide))
            {
                Debug.Log("Нелья ударить");
                return;
            }
            _turnController.SetNeturalSide();
            HeroDTO turnHero = _turnController.GetTurnUnit();
            turnHero.HeroController.Attack(_heroModel.HeroDto);
        }

        public void DoMove()
        {
            _heroUi.DoMove();
        }

        private void NewTurn(EventArgs evt)
        {
            _heroUi.RefreshTurnImage();
        }
    }
}
