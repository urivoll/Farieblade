using Core.InGame.DTO;
using Core.InGame.Spells.Effects;
using Core.InGame.Utils;
using Events;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.InGame.Spells
{
    public class HeroEffects : EventBehaviour
    {
        private List<Effect> effects;
        [SerializeField] private Transform _container;

        [Inject] private Factory _factory;

        private HeroDTO _heroDTO;

        public void Open(HeroDTO heroDTO)
        {
            _heroDTO = heroDTO;
        }

        public void AddNewEffect(GameObject newEffect)
        {
            Effect effect = _factory.CreateEffect(_container, newEffect);
            effects.Add(effect);
            effect.Open(_heroDTO);
        }
    }
}