using Core.InGame.DTO;
using Core.InGame.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using EventArgs = Events.EventArgs;

namespace Core.InGame.Controller
{
    public class UnitCoordinatorController : Events.EventDispatcher
    {
        [Inject] private UnitCoordinatorModel _unitCoordinatorModel;
        [Inject] private TurnController _turnController;

        public void Open(Dictionary<int, HeroDTO> leftSide, Dictionary<int, HeroDTO> rightSide)
        {
            _unitCoordinatorModel.Open(leftSide, rightSide);
        }

        public HeroDTO GetHeroByPosition(int position, TurnSide side)
        {
            return _unitCoordinatorModel.GetHeroByPosition(position, side);
        }

        public void Close()
        {
        }

        public void KillHero(int position, TurnSide turnSide)
        {
            bool end = _unitCoordinatorModel.KillHeroAndCheckEndGame(position, turnSide);
            if (end)
            {
                _turnController.StopGame();
                if (turnSide == TurnSide.right) Debug.Log("Мы победили!");
                else Debug.Log("Мы проиграли!");
            }
        }

        public void SetAvaibleTargets(SpellState state, HeroDTO turnHero)
        {
            _unitCoordinatorModel.CallAvaibleUnits(state, turnHero.TurnSide, turnHero.Position);
            DispatchEvent("Set avaible", _unitCoordinatorModel.AvaibleHeroes, turnHero, _unitCoordinatorModel.AvaibleHeroesSide);
        }

        public bool TryToAttack(int position, TurnSide targetSide)
        {
            return _unitCoordinatorModel.CheckForAvaibleToHit(position, targetSide);
        }
    }
}

public enum AttackType
{
    magic,
    attack
}