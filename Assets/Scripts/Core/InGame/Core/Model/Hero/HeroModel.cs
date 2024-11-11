using Core.InGame.DTO;
using System;
using UnityEngine;
using System.Collections.Generic;
using EventDispatcher = Events.EventDispatcher;
using Random = UnityEngine.Random;

namespace Core.InGame.Model
{
    public class HeroModel : EventDispatcher
    {
        private HeroDTO _heroDto;
        private int _position;
        private TurnSide _turnSide;
        private HeroDTO _attackedHero;

        public HeroDTO AttackedHero => _attackedHero;
        public int Position => _position;
        public TurnSide TurnSide => _turnSide;
        public HeroDTO HeroDto => _heroDto;

        public void Open(HeroDTO heroDto, TurnSide turnSide, int position)
        {
            _heroDto = heroDto;
            _turnSide = turnSide;
            _position = position;
        }

        public bool CheckHit()
        {
            int random = Random.Range(0, 100);
            if(random > _heroDto.Accuarcy) return false;
            return true;
        }

        public List<float> GetHpDamage()
        {
            List<float> tempList = new();
            tempList.Add(_heroDto.Hp);
            tempList.Add(_heroDto.Damage);
            return tempList;
        } 

        public HeroUI_takeDamageDTO TakeDamage(float damage)
        {
            _heroDto.Hp -= damage;
            _heroDto.HpPercentage = _heroDto.Hp * 100 / _heroDto.HpBasic;
            HeroUI_takeDamageDTO data = new(_heroDto.Hp, _heroDto.HpPercentage);
            return data;
        }

        public void SetAttackedHero(HeroDTO attackedHero)
        {
            _attackedHero = attackedHero;
        }

        public void RemoveAttackedHero()
        {
            _attackedHero = null;
        }
    }
}