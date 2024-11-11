using Core.InGame.Controller;
using Core.InGame.DTO;
using Events;
using Zenject;

namespace Core.InGame.Utils
{
    public class MeleeAttack : EventDispatcher
    {
        [Inject] private CirclesController _circlesController;
        [Inject] private UnitCoordinatorController _unitCoordinatorController;
        [Inject] private TurnController _turnController;

        private bool TempPosition;
        private HeroDTO _moveOverHero = null;
        private HeroDTO _fromHero = null;
        private HeroDTO _toHero = null;

        public void Open()
        {
            _turnController.AddListener("End step", Refresh);
        }

        public void Close() 
        {
            _turnController.RemoveListener("End step", Refresh);
        }

        public void Attack(HeroDTO heroFrom, HeroDTO heroTo)
        {
            MoveTo(heroFrom, heroTo);
        }

        private void MoveTo(HeroDTO heroFrom, HeroDTO heroTo)
        {
            if (heroTo.Position == heroFrom.Position) return;
            _fromHero = heroFrom;
            _toHero = heroTo;
            CirclePosition circlePosition;
            if (heroTo.Position == 1 || heroTo.Position == 3 || heroTo.Position == 5)
            {
                circlePosition = _circlesController.GetCirclePosition(heroTo.Position - 1, heroTo.TurnSide);
            }
            else
            {
                circlePosition = _circlesController.GetCirclePosition(heroTo.Position, heroFrom.TurnSide);
                HeroDTO hero = _unitCoordinatorController.GetHeroByPosition(heroTo.Position, heroFrom.TurnSide);
                if (hero != null)
                {
                    _moveOverHero = hero;
                    hero.HeroController.MoveOver();
                }
            }
            heroFrom.HeroController.SetPosition(circlePosition);
        }

        private void MoveBack()
        {
            if (_fromHero == null) return;
            CirclePosition circlePosition = _circlesController.GetCirclePosition(_fromHero.Position, _fromHero.TurnSide);
            _fromHero.HeroController.SetPosition(circlePosition);
            if (_moveOverHero != null)
            {
                _moveOverHero.HeroController.MoveOverBack();
                _moveOverHero = null;
            }
        }

        private void Refresh(EventArgs evt)
        {
            _moveOverHero = null;
            _fromHero = null;
            _toHero = null;
            MoveBack();
        }
    }
}