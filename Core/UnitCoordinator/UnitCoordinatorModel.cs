using Core.InGame.DTO;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.InGame.Model
{
    public class UnitCoordinatorModel
    {
        private Dictionary<int, HeroDTO> _avaibleHeroes = new();
        private TurnSide _avaibleHeroesSide;

        private Dictionary<int, HeroDTO>[] _sides = new Dictionary<int, HeroDTO>[2] ;
        private int[] samplePositions = new int[3] { 0, 2, 4 };
        private TurnSide _turnHeroSide;
        private Action<Dictionary<int, HeroDTO>, bool>[] methodListMelee;

        public Dictionary<int, HeroDTO> AvaibleHeroes => _avaibleHeroes;
        public TurnSide AvaibleHeroesSide => _avaibleHeroesSide;

        public void Open(Dictionary<int, HeroDTO> leftSide, Dictionary<int, HeroDTO> rightSide)
        {
            methodListMelee = new Action<Dictionary<int, HeroDTO>, bool>[3] 
            { 
                SetAvaibleUnitsMeleeTop, 
                SetAvaibleUnitsMeleeCenter, 
                SetAvaibleUnitsMeleeBot 
            };
            _sides[0] = leftSide;
            _sides[1] = rightSide;
        }

        public HeroDTO GetHeroByPosition(int position, TurnSide side)
        {
            if (_sides[(int)side].ContainsKey(position)) return _sides[(int)side][position];
            else return null; 
        }

        public bool KillHeroAndCheckEndGame(int position, TurnSide turnSide)
        {
            _sides[(int)turnSide].Remove(position);
            if (_sides[(int)turnSide].Count <= 0) return true;
            else return false;
        }

        public bool CheckForAvaibleToHit(int position, TurnSide targetSide)
        {
            if(_avaibleHeroes.ContainsKey(position) && targetSide == _avaibleHeroesSide) return true;
            else return false;
        }

        public void CallAvaibleUnits(SpellState turnHeroAttackState, TurnSide turnHeroSide, int turnHeroPosition)
        {
            if (_avaibleHeroes.Count > 0) _avaibleHeroes.Clear();

            samplePositions = new int[] { 0, 2, 4 };
            _turnHeroSide = turnHeroSide;

            _avaibleHeroesSide = (turnHeroAttackState == SpellState.melee || turnHeroAttackState == SpellState.range)
                ? (turnHeroSide == TurnSide.left ? TurnSide.right : TurnSide.left)
                : turnHeroSide;

            if (turnHeroAttackState == SpellState.melee)
            {
                int index = Array.IndexOf(samplePositions, turnHeroPosition);
                if (index >= 0) methodListMelee[index](_sides[(int)_avaibleHeroesSide], false);
            }
            else if (turnHeroAttackState == SpellState.range)
            {
                SetAvaibleUnitsRange(_sides[(int)_avaibleHeroesSide]);
            }
            foreach (var item in _avaibleHeroes)
            {
                Debug.Log("Перечисление доступных героев " + item.Value.Position + " " + item.Value.TurnSide);
            }
        }


        private void SetAvaibleUnitsRange(Dictionary<int, HeroDTO> positions)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                _avaibleHeroes[i] = positions[i];
            }
        }
        //
        private void SetAvaibleUnitsMeleeTop(Dictionary<int, HeroDTO> positions, bool replay = false)
        {
            int count = 0;
            if (positions.ContainsKey(samplePositions[0]))
            {
                _avaibleHeroes[samplePositions[0]] = positions[samplePositions[0]];
                count++;
            }
            if (positions.ContainsKey(samplePositions[1]))
            {
                _avaibleHeroes[samplePositions[1]] = positions[samplePositions[1]];
                count++;
            }
            if (count == 0)
            {
                if (positions.ContainsKey(samplePositions[2]))
                {
                    _avaibleHeroes[samplePositions[2]] = positions[samplePositions[2]];
                    count++;
                }
                if (count == 0 && !replay)
                {
                    samplePositions = new int[3] { 1, 3, 5 };
                    SetAvaibleUnitsMeleeTop(positions, true);
                }
            }
        }

        private void SetAvaibleUnitsMeleeCenter(Dictionary<int, HeroDTO> positions, bool replay = false)
        {
            int count = 0;
            if (positions.ContainsKey(samplePositions[0]))
            {
                _avaibleHeroes[samplePositions[0]] = positions[samplePositions[0]];
                count++;
            }
            if (positions.ContainsKey(samplePositions[1]))
            {
                _avaibleHeroes[samplePositions[1]] = positions[samplePositions[1]];
                count++;
            }
            if (positions.ContainsKey(samplePositions[2]))
            {
                _avaibleHeroes[samplePositions[2]] = positions[samplePositions[2]];
                count++;
            }
            if (count == 0 && !replay)
            {
                samplePositions = new int[3] { 1, 3, 5 };
                SetAvaibleUnitsMeleeCenter(positions, true);
            }
        }

        private void SetAvaibleUnitsMeleeBot(Dictionary<int, HeroDTO> positions, bool replay = false)
        {
            int count = 0;
            if (positions.ContainsKey(samplePositions[2]))
            {
                _avaibleHeroes[samplePositions[2]] = positions[samplePositions[2]];
                count++;
            }
            if (positions.ContainsKey(samplePositions[1]))
            {
                _avaibleHeroes[samplePositions[1]] = positions[samplePositions[1]];
                count++;
            }
            if (count == 0)
            {
                if (positions.ContainsKey(samplePositions[0]))
                {
                    _avaibleHeroes[samplePositions[0]] = positions[samplePositions[0]];
                    count++;
                }
                if (count == 0 && !replay)
                {
                    samplePositions = new int[3] { 1, 3, 5 };
                    SetAvaibleUnitsMeleeTop(positions, true);
                }
            }
        }
    }
}

public enum SpellState
{
    melee,
    range,
    our
}

public enum PositionForHit
{
    first, 
    second, 
    third
}

public enum TurnSide
{
    left, right, netural
}