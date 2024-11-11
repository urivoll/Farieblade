using EventDispatcher = Events.EventDispatcher;

namespace Core.InGame.Model
{
    public class PlayerModel : EventDispatcher
    {
        private TurnSide _mySide = TurnSide.left;
        public TurnSide MySide => _mySide;

    }
}
