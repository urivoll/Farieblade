using Core.Screens.View.City;
using Events;
using Server;
using UI.Manager;
using Zenject;
using EventArgs = Events.EventArgs;

namespace Core.Screens.Controller.Main
{
    public class AlchemyController : EventDispatcher
    {
        [Inject] private AlchemyView.Factory _alchemyViewFactory;

        private AlchemyView _alchemyView;
        private RequestBuilder _requestBuilder;
        private AppController _appController;

        public void Open()
        {
            _alchemyView = _alchemyViewFactory.Create();
            _alchemyView.Open();
            _alchemyView.AddListener(EventManager.OnClickBack, HandlerBackEvent);
        }

        public void Close()
        {
            _alchemyView.RemoveListener(EventManager.OnClickBack, HandlerBackEvent);
            _alchemyView.OnDestroy();
        }

        private void HandlerBackEvent(EventArgs evt)
        {
            DispatchEvent(EventManager.OnClickBack);
        }
    }
}
