using Core.InGame.DTO;
using System;
using System.Collections.Generic;
using EventDispatcher = Events.EventDispatcher;

namespace Core.InGame.Model
{
    public class TurnModel : EventDispatcher
    {
        private int _currentTurn;
        private TurnSide _turnSide;
        private List<HeroDTO> _allHeroes = new();
        private List<HeroDTO> _notStepHeroes = new();
        private HeroDTO _turnHero;
        private bool _endGame = false;

        public bool EndGame => _endGame;
        public int CurrentTurn => _currentTurn;
        public TurnSide TurnSide => _turnSide;
        public HeroDTO TurnHero => _turnHero;


        public void Open(List<HeroDTO> listHeroes)
        {
            _currentTurn = 1;
            _allHeroes = listHeroes;
            _notStepHeroes.AddRange(_allHeroes);
        }

        public void SetNeturalSide()
        {
            _turnSide = TurnSide.netural;
        }

        public void StopGame()
        {
            _endGame = true;
        }

        public void Close()
        {
            
        }

        public void KillHero(HeroDTO hero)
        {
            _allHeroes.Remove(hero);
            if(_notStepHeroes.Contains(hero)) _notStepHeroes.Remove(hero);
            if(_turnHero == hero) _turnHero = null;
        }

        public void NewStep()
        {
            if (EndGame) return;
            if (_notStepHeroes.Count <= 0) ChangeTurn();
            FindMaxInitiative();
            _notStepHeroes.Remove(_turnHero);
            _turnSide = _turnHero.TurnSide;
        }

        private void FindMaxInitiative()
        {
            int maxInitiative = 0;
            for (int i = 0; i < _notStepHeroes.Count; i++)
            {
                if (_notStepHeroes[i].Initiative > maxInitiative)
                {
                    maxInitiative = _notStepHeroes[i].Initiative;
                    _turnHero = _notStepHeroes[i];
                }
                else if (_notStepHeroes[i].Initiative == maxInitiative)
                {
                    Random random = new();
                    int randomUnit = random.Next(0, 2);
                    if (randomUnit == 0) _turnHero = _notStepHeroes[i];
                }
            }
        }

        public void RemoveHeroFromQueue(HeroDTO hero)
        {
            _notStepHeroes.Remove(hero);
        }

        public int ChangeTurn()
        {
            _notStepHeroes.AddRange(_allHeroes);
            _currentTurn++;
            DispatchEvent("Change turn", _currentTurn);
            return _currentTurn;
        }
    }
}
