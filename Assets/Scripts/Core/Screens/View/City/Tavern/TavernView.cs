using Events;
using UI.Manager;
using UI.UIElement;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Screens.View.City
{
    public class TavernView : EventBehaviour
    {
        [SerializeField] private Button _backButton;

        public void Open()
        {
            _backButton.onClick.AddListener(HandlerBackEvent);
        }

        public void OnDestroy()
        {
            _backButton.onClick.RemoveListener(HandlerBackEvent);
            Destroy(gameObject);
        }

        private void HandlerBackEvent()
        {
            DispatchEvent(EventManager.OnClickBack);
        }

        public class Factory : UIFactory<TavernView> { }
    }
}
