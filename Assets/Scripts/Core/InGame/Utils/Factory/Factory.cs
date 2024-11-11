using Core.InGame.Controller;
using Core.InGame.DTO;
using Core.InGame.Model;
using Core.InGame.Spells.Effects;
using Core.InGame.View;
using Events;
using InGame.Utils;
using System;
using UnityEngine;
using Zenject;

namespace Core.InGame.Utils
{
    public class Factory : EventBehaviour
    {
        [Inject] private DiContainer _container;

        [SerializeField] private SOheroes[] _soHeroes;
        [SerializeField] private HeroUI _heroUI;
        [SerializeField] private Transform _unitContainer;

        public HeroController CreateNewHero(int position, TurnSide turnSide, int idHero)
        {
            GameObject hero = _container.InstantiatePrefab(_soHeroes[idHero].Prefab);
            hero.transform.SetParent(_unitContainer);
            HeroController heroController = _container.Instantiate<HeroController>();
            HeroModel heroModel = _container.Instantiate<HeroModel>();
            HeroDTO heroDTO = new HeroDTO();
            heroDTO.Init(_soHeroes[idHero], heroController, turnSide, position);
            heroModel.Open(heroDTO, turnSide, position);
            GameObject heroUI = _container.InstantiatePrefab(_heroUI);
            heroController.Open(hero.GetComponent<HeroView>(), heroModel, heroUI.GetComponent<HeroUI>());
            return heroController;
        }

        public Projectile CreateProjectile(Vector2 fromPosition, Vector2 toPosition, GameObject projectilePrefab)
        {
            GameObject projectile = _container.InstantiatePrefab(projectilePrefab);
            projectile.transform.position = fromPosition;
            var direction = toPosition - fromPosition;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
            return projectile.GetComponent<Projectile>();
        }

        public Effect CreateEffect(Transform container, GameObject effectPrefab)
        {
            GameObject effect = _container.InstantiatePrefab(effectPrefab);
            effect.transform.SetParent(container.transform);
            return effect.GetComponent<Effect>();
        }
    }
}
