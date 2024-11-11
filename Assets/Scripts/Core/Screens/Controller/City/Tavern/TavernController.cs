using Core.Screens.View.City;
using Events;
using Server;
using UI.Manager;
using Zenject;
using EventArgs = Events.EventArgs;

namespace Core.Screens.Controller.Main
{
    public class TavernController : EventDispatcher
    {
        [Inject] private TavernView.Factory _tavernViewFactory;

        private TavernView _tavernView;
        private RequestBuilder _requestBuilder;
        private AppController _appController;

        public void Open()
        {
            _tavernView = _tavernViewFactory.Create();
            _tavernView.Open();
            _tavernView.AddListener(EventManager.OnClickBack, HandlerBackEvent);
        }

        public void Close()
        {
            _tavernView.RemoveListener(EventManager.OnClickBack, HandlerBackEvent);
            _tavernView.OnDestroy();
        }

        private void HandlerBackEvent(EventArgs evt)
        {
            DispatchEvent(EventManager.OnClickBack);
        }
    }
}
