using Core.InGame.Controller;
using Core.InGame.DTO;
using Events;
using UnityEngine;
using Zenject;

namespace Core.InGame.Spells
{
    public class HeroSpells : EventBehaviour
    {
        [Inject] private UnitCoordinatorController _unitCoordinatorController;

        [SerializeField] private Spell[] _spells;

        private HeroDTO _heroDTO;

        public void Open(HeroDTO heroDTO)
        {
            _heroDTO = heroDTO;
        }

        public void ChooseSpell(int index)
        {
            _unitCoordinatorController.SetAvaibleTargets(_spells[index].SpellState, _heroDTO);
        }
    }
}