using Core.InGame.DTO;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Core.InGame.Controller
{
    public class AiModel
    {
        private TurnSide _turnSide;
        private bool _ai = false;

        public TurnSide TurnSide => _turnSide;
        public bool Ai => _ai;

        public void Open(TurnSide turnSide)
        {
            _turnSide = turnSide;
        }

        public void AiOn(bool on)
        {
            _ai = on;
        }

        public HeroDTO ChooseHero(List<HeroDTO> avaibleHeroes)
        {
            int random = Random.Range(0, avaibleHeroes.Count);
            return avaibleHeroes[random];
        }
    }
}
