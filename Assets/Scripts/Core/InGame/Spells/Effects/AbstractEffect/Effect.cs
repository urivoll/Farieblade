using Core.InGame.Controller;
using Core.InGame.DTO;
using Events;
using UnityEngine;
using Zenject;

namespace Core.InGame.Spells.Effects
{
    public abstract class Effect : EventBehaviour
    {
        [Inject] private TurnController _turnController;

        protected HeroDTO _parentHero;
        protected int _turnOver;

        public virtual void Open(HeroDTO parentHero) 
        {
            _parentHero = parentHero;
            _turnController.AddListener("New step", EffectOver);
        }

        private void EffectOver(EventArgs evt)
        {
            HeroDTO turnHero = evt.args[1] as HeroDTO;
            int currentTurn = _turnController.GetTurnInt();
            if (_parentHero != turnHero || currentTurn != _turnOver) return;
            
        }

        public virtual void OnDestroy()
        {

        }
    }
}