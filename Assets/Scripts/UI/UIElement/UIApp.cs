using JetBrains.Annotations;
using UnityEngine;

namespace UI.UIElement
{
    public class UIApp : MonoBehaviour
    {
        private GameObject _root;
        private SafeAreaLayout _safeArea;

        public void Awake()
        {
            _root = gameObject;
            _safeArea = _root.GetComponentInChildren<SafeAreaLayout>();
        }

        public void Add(Component child, bool inSafeArea = true)
        {
            child.transform.SetParent(inSafeArea ? _safeArea.transform : _root.transform, false);
        }
    }
}
