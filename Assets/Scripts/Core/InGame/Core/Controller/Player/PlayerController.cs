using Core.InGame.DTO;
using Core.InGame.Model;
using Core.InGame.Utils;
using System.Collections.Generic;
using Zenject;
using EventDispatcher = Events.EventDispatcher;

namespace Core.InGame.Controller
{
    public class PlayerController : EventDispatcher
    {
        [Inject] private PlayerModel _playerModel;
        [Inject] private Factory _factory;
        [Inject] private UnitCoordinatorController _unitCoordinatorController;
        [Inject] private TurnController _turnController;

        public TurnSide GetMySide()
        {
            return _playerModel.MySide;
        }

        public void Open()
        {
            Dictionary<int, HeroDTO> heroDTOsDictLeft = new();
            Dictionary<int, HeroDTO> heroDTOsDictRight = new();
            List<HeroDTO> heroDTOs = new();
            heroDTOsDictLeft[0] = _factory.CreateNewHero(0, TurnSide.left, 2).GetHeroProperties();
            heroDTOsDictRight[0] = _factory.CreateNewHero(0, TurnSide.right, 1).GetHeroProperties();
            heroDTOsDictLeft[2] = _factory.CreateNewHero(2, TurnSide.left, 2).GetHeroProperties();
            heroDTOsDictRight[2] = _factory.CreateNewHero(2, TurnSide.right, 1).GetHeroProperties();
            heroDTOsDictLeft[4] = _factory.CreateNewHero(4, TurnSide.left, 2).GetHeroProperties();
            heroDTOsDictRight[4] = _factory.CreateNewHero(4, TurnSide.right, 1).GetHeroProperties();

            heroDTOs.Add(heroDTOsDictLeft[0]);
            heroDTOs.Add(heroDTOsDictRight[0]);
            heroDTOs.Add(heroDTOsDictLeft[2]);
            heroDTOs.Add(heroDTOsDictRight[2]);
            heroDTOs.Add(heroDTOsDictLeft[4]);
            heroDTOs.Add(heroDTOsDictRight[4]);
            _unitCoordinatorController.Open(heroDTOsDictLeft, heroDTOsDictRight);
            _turnController.Open(heroDTOs);
        }
    }
}
