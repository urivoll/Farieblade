using Core.InGame.Controller;
using Core.InGame.UI.View;
using Events;
using Zenject;

namespace Core.InGame.UI.Controller
{
    public class SettingsController : EventDispatcher
    {
        [Inject] private SettingsView _settingsView;
        [Inject] private AiController _aiController;
        [Inject] private CirclesController _circlesController;

        public void Open(bool ai, int view)
        {
            _settingsView.Open(ai, view);
            _settingsView.AddListener("Change ai", HandlerChangeAiEvent);
            _settingsView.AddListener("Change view", HandlerChangeViewEvent);
        }

        public void Close()
        {
            _settingsView.OnDestroy();
            _settingsView.RemoveListener("Change ai", HandlerChangeAiEvent);
            _settingsView.RemoveListener("Change view", HandlerChangeViewEvent);
        }

        private void HandlerChangeAiEvent(EventArgs evt)
        {
            var ai = (bool)evt.args[0];
            _aiController.AiOn(ai);
        }

        private void HandlerChangeViewEvent(EventArgs evt)
        {
            var view = (int)evt.args[0];
            _circlesController.HandlerSetViewEvent(view);
        }
    }
}