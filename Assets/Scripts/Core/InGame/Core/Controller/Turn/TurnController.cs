using Core.InGame.DTO;
using Core.InGame.Model;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Zenject;
using Events;
using EventDispatcher = Events.EventDispatcher;
using Core.InGame.Utils;

namespace Core.InGame.Controller
{
    public class TurnController : EventDispatcher
    {
        [Inject] private TurnModel _turnModel;
        [Inject] private GameSpeed _gameSpeed;

        public void Open(List<HeroDTO> listHero)
        {
            _turnModel.Open(listHero);
            _turnModel.AddListener("Change turn", ChangeTurn);
        }

        public void Close()
        {
            _turnModel.Close();
            _turnModel.RemoveListener("Change turn", ChangeTurn);
        }

        public void StopGame()
        {
            _turnModel.StopGame();
        }

        public void ChangeTurn(EventArgs evt)
        {
            var turnIndex = (int)evt.args[0];
            DispatchEvent("Change turn", turnIndex);
        }

        public void KillHero(HeroDTO hero)
        {
            _turnModel.KillHero(hero);
        }

        public HeroDTO GetTurnUnit()
        {
            return _turnModel.TurnHero;
        }

        public int GetTurnInt()
        {
            return _turnModel.CurrentTurn;
        }

        public void SetNeturalSide()
        {
            _turnModel.SetNeturalSide();
        }

        public async void EndStep()
        {
            _turnModel.TurnHero.HeroController.DoMove();
            DispatchEvent("End step");
            int speed = _gameSpeed.GetGameSpeed();
            await UniTask.Delay(100 / speed);
            StartStep();
        }

        public void StartStep()
        {
            if (_turnModel.EndGame) return;
            _turnModel.NewStep();
            _turnModel.TurnHero.HeroController.SetCurrentSpell();
            DispatchEvent("New step", _turnModel.TurnSide, _turnModel.TurnHero);
        }

        public bool CheckIsYourTurn(TurnSide turnSide)
        {
            return _turnModel.TurnSide == turnSide;
        }


    }
}
