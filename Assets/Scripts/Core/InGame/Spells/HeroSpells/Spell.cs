using Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.InGame.Spells
{
    public abstract class Spell : EventBehaviour
    {
        public AttackType AttackType;
        public SpellState SpellState;
        public abstract void UseSpell();
    }
}