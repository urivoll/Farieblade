using Core.Screens.View.City;
using Events;
using Server;
using UI.Manager;
using Zenject;
using EventArgs = Events.EventArgs;

namespace Core.Screens.Controller.Main
{
    public class DealerController : EventDispatcher
    {
        [Inject] private DealerView.Factory _dealerViewFactory;

        private DealerView _dealerView;
        private RequestBuilder _requestBuilder;
        private AppController _appController;

        public void Open()
        {
            _dealerView = _dealerViewFactory.Create();
            _dealerView.Open();
            _dealerView.AddListener(EventManager.OnClickBack, HandlerBackEvent);
        }

        public void Close()
        {
            _dealerView.RemoveListener(EventManager.OnClickBack, HandlerBackEvent);
            _dealerView.OnDestroy();
        }

        private void HandlerBackEvent(EventArgs evt)
        {
            DispatchEvent(EventManager.OnClickBack);
        }
    }
}
