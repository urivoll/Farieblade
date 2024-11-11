using Core.InGame.Controller;
using Events;
using Zenject;

namespace Core.InGame.UI.Controller
{
    public class BotSideController : EventDispatcher
    {
        [Inject] private TurnController _turnController;
        [Inject] private BotSideView _botSideView;
        
        public void Open(string leftName, string rightName = null)
        {
            _botSideView.Open(leftName, rightName);
            _turnController.AddListener("Change turn", HandlerChangeTrunEvent);
        }

        public void Close()
        {
            _turnController.RemoveListener("Change turn", HandlerChangeTrunEvent);
        }

        private void HandlerChangeTrunEvent(EventArgs evt)
        {
            var turn = (int)evt.args[0];
            _botSideView.ChangeTurn(turn);
        }
    }
}