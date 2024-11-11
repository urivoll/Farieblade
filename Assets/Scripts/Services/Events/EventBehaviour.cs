using UnityEngine;

namespace Events
{
    public class EventBehaviour : MonoBehaviour
    {
        protected EventDispatcher EventDispatcher { get; set; }

        public EventBehaviour()
        {
            EventDispatcher = new EventDispatcher();
        }

        public void AddListener(string eventType, EventListener.EventHandler eventHandler)
        {
            EventDispatcher?.AddListener(eventType, eventHandler);
        }

        public void RemoveListener(string eventType, EventListener.EventHandler eventHandler)
        {
            EventDispatcher?.RemoveListener(eventType, eventHandler);
        }

        public void DispatchEvent(string eventType, params object[] args)
        {
            EventDispatcher?.DispatchEvent(eventType, args);
        }

        private void OnDestroy()
        {
            EventDispatcher?.Clear();
            EventDispatcher = null;
        }
    }
}
