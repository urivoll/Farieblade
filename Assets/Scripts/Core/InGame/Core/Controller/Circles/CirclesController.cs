using Events;
using UnityEngine;
using Zenject;
using EventDispatcher = Events.EventDispatcher;
using System.Collections.Generic;
using System.Linq;
using Core.InGame.DTO;
using Core.InGame.View;

namespace Core.InGame.Controller
{
    public class CirclesController : EventDispatcher
    {
        [Inject] private CirclesView _circlesView;
        [Inject] private TurnController _turnController;
        [Inject] private UnitCoordinatorController _unitCoordinatorController;
        [Inject] private PlayerController _playerController;

        public void Open()
        {
            _circlesView.Open();
            _turnController.AddListener("End step", HandlerRefreshEvent);
            _unitCoordinatorController.AddListener("Set avaible", HandlerAvaibleUnitsEvent);
        }

        public void Close()
        {
            _turnController.RemoveListener("End step", HandlerRefreshEvent);
            _unitCoordinatorController.RemoveListener("Set avaible", HandlerAvaibleUnitsEvent);
        }

        public CirclePosition GetCirclePosition(int indexPosition, TurnSide turnSide)
        {
            return _circlesView.GetCirclePosition(indexPosition, turnSide);
        }

        private void HandlerRefreshEvent(EventArgs evt)
        {
            _circlesView.HandlerRefreshEvent();
        }

        private void HandlerAvaibleUnitsEvent(EventArgs evt)
        {
            var dict = evt.args[0] as Dictionary<int, HeroDTO>;
            var turnHero = evt.args[1] as HeroDTO;
            var turnSide = (TurnSide)evt.args[2];
            
            List<int> positions = dict.Keys.ToList();
            _circlesView.HightlightCircles(positions, turnHero, turnSide, _playerController.GetMySide());
        }

        public void HandlerSetViewEvent(int index)
        {
            _circlesView.HandlerSetViewEvent(index);
            DispatchEvent("Change view");
        }
    }
}

public class CirclePosition
{
    public Vector2 Position { get; set; }
    public int SortingOrder { get; set; }
    public Vector3 Size { get; set; }
}