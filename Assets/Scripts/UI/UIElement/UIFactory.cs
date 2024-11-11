using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace UI.UIElement
{
    [UsedImplicitly]
    public class UIFactory<T> : PlaceholderFactory<T>
        where T : Component
    {
        private UIApp _uiApp;

        [Inject]
        public void Construct(UIApp uIApp)
        {
            _uiApp = uIApp;
        }

        public override T Create()
        {
            var instance = base.Create();
            _uiApp.Add(instance);
            return instance;
        }
    }
}
