using Core.InGame.DTO;
using Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core.InGame.Controller
{
    public class AiController : EventDispatcher
    {
        [Inject] private AiModel _aiModel;
        [Inject] private TurnController _turnController;
        [Inject] private UnitCoordinatorController _unitCoordinatorController;

        private EventArgs currentArgs;

        public void Open(TurnSide turnSide)
        {
            _aiModel.Open(turnSide);
            _unitCoordinatorController.AddListener("Set avaible", DoAStep);
        }

        public void AiOn(bool on)
        {
            _aiModel.AiOn(on);
            if(on)
            {
                if(currentArgs != null)
                DoAStep(currentArgs);
            }
        }

        private void DoAStep(EventArgs evt)
        {
            Debug.Log("AiController отреагировал на событие Set avaible");
            var turnHero = evt.args[1] as HeroDTO;

            currentArgs = evt;
            if (_aiModel.TurnSide != turnHero.TurnSide && !_aiModel.Ai) return;
            currentArgs = null;
            var dict = evt.args[0] as Dictionary<int, HeroDTO>;
            var turnSide = (TurnSide)evt.args[2];
            List<HeroDTO> heroDTOs = dict.Values.ToList();
            HeroDTO hero = _aiModel.ChooseHero(heroDTOs);
            Debug.Log("ИИ выбрал цель для атаки с позицией: " + hero.Position + ", Стороной: " + hero.TurnSide);
            hero.HeroController.TryToUseSpell(turnHero.TurnSide);
        }

        public void Close()
        {
            _unitCoordinatorController.RemoveListener("Set avaible", DoAStep);
        }
    }
}
