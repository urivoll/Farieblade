using System.Collections.Generic;

namespace Events
{
    public class EventDispatcher
    {
        private Dictionary<string, EventListener> dic = new Dictionary<string, EventListener>();

        public void AddListener(string eventType, EventListener.EventHandler eventHandler)
        {
            EventListener invoker;
            if (!dic.TryGetValue(eventType, out invoker))
            {
                invoker = new EventListener();
                dic.Add(eventType, invoker);
            }

            invoker.eventHandler += eventHandler;
        }

        public void RemoveListener(string eventType, EventListener.EventHandler eventHandler)
        {
            EventListener invoker;
            if (dic.TryGetValue(eventType, out invoker)) invoker.eventHandler -= eventHandler;
        }

        public bool HasListener(string eventType)
        {
            return dic.ContainsKey(eventType);
        }

        public void DispatchEvent(string eventType, params object[] args)
        {
            EventListener invoker;
            if (dic.TryGetValue(eventType, out invoker))
            {
                EventArgs evt;
                if (args == null || args.Length == 0)
                {
                    evt = new EventArgs(eventType);
                }
                else
                {
                    evt = new EventArgs(eventType, args);
                }

                invoker.Invoke(evt);
            }
        }

        public virtual void Clear()
        {
            foreach (EventListener value in dic.Values)
            {
                value.Clear();
            }
            dic.Clear();
        }
    }
}
