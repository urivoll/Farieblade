using Events;
using UI.Manager;
using UI.UIElement;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Screens.View.City
{
    public class CityView : EventBehaviour
    {
        [SerializeField] private Button _alchemyButton;
        [SerializeField] private Button _tavern;
        [SerializeField] private Button _dealer;

        public void Open()
        {
            _alchemyButton.onClick.AddListener(HandlerToAlchemyEvent);
            _tavern.onClick.AddListener(HandlerToTavernEvent);
            _dealer.onClick.AddListener(HandlerToDealerEvent);
        }

        public void OnDestroy()
        {
            _alchemyButton.onClick.RemoveListener(HandlerToAlchemyEvent);
            _tavern.onClick.RemoveListener(HandlerToTavernEvent);
            _dealer.onClick.RemoveListener(HandlerToDealerEvent);
            Destroy(gameObject);
        }

        private void HandlerToAlchemyEvent()
        {
            DispatchEvent(EventManager.AlchemyScreen);
        }

        private void HandlerToTavernEvent()
        {
            DispatchEvent(EventManager.TavernScreen);
        }

        private void HandlerToDealerEvent()
        {
            DispatchEvent(EventManager.DealerScreen);
        }

        public class Factory : UIFactory<CityView> { }
    }
}
