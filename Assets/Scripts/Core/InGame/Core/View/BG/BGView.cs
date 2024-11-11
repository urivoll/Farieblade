using Events;
using UnityEngine;

namespace Core.InGame.View
{
    public class BGView : EventBehaviour
    {
        [SerializeField] private GameObject[] _bgPrefabs;

        private GameObject _bg;

        public void Open(int index)
        {
            if (index == -1) index = Random.Range(0, _bgPrefabs.Length);
            _bg = Instantiate(_bgPrefabs[index], transform);
        }
    }
}