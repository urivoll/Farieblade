using Core.Screens.View.City;
using Server;
using UI.Manager;
using Zenject;
using EventArgs = Events.EventArgs;

namespace Core.Screens.Controller.Main
{
    public class TopPanelView
    {
        [Inject] private CityView.Factory _cityViewFactory;
        [Inject] private AlchemyController _alchemyController;
        [Inject] private TavernController _tavernController;
        [Inject] private DealerController _dealerController;

        private CityView _cityView;
        private RequestBuilder _requestBuilder;
        private AppController _appController;

        public void Open()
        {
            _cityView = _cityViewFactory.Create();
            _cityView.transform.SetSiblingIndex(0);
            _cityView.Open();
            _cityView.AddListener(EventManager.TavernScreen, HandlerToTavernEvent);
            _cityView.AddListener(EventManager.DealerScreen, HandlerToDealerEvent);
            _cityView.AddListener(EventManager.AlchemyScreen, HandlerToAlchemyEvent);
        }

        public void Close()
        {
            _cityView.RemoveListener(EventManager.TavernScreen, HandlerToTavernEvent);
            _cityView.RemoveListener(EventManager.DealerScreen, HandlerToDealerEvent);
            _cityView.RemoveListener(EventManager.AlchemyScreen, HandlerToAlchemyEvent);
            _cityView.OnDestroy();
        }

        private void TransitionToTavern()
        {
            _tavernController.Open();
            _tavernController.AddListener(EventManager.OnClickBack, TransitionFromTavern);
        }

        private void TransitionFromTavern(EventArgs evt)
        {
            _tavernController.Close();
            _tavernController.RemoveListener(EventManager.OnClickBack, TransitionFromTavern);
        }

        private void TransitionToDealer()
        {
            _dealerController.Open();
            _dealerController.AddListener(EventManager.OnClickBack, TransitionFromDealer);
        }

        private void TransitionFromDealer(EventArgs evt)
        {
            _dealerController.Close();
            _dealerController.RemoveListener(EventManager.OnClickBack, TransitionFromDealer);
        }

        private void TransitionToAlchemy()
        {
            _alchemyController.Open();
            _alchemyController.AddListener(EventManager.OnClickBack, TransitionFromAlchemy);
        }

        private void TransitionFromAlchemy(EventArgs evt)
        {
            _alchemyController.Close();
            _alchemyController.RemoveListener(EventManager.OnClickBack, TransitionFromAlchemy);
        }

        private void HandlerToTavernEvent(EventArgs evt)
        {
            TransitionToTavern();
        }

        private void HandlerToDealerEvent(EventArgs evt)
        {
            TransitionToDealer();
        }

        public void HandlerToAlchemyEvent(EventArgs evt)
        {
            TransitionToAlchemy();
        }
    }
}
