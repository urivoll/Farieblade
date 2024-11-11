using Core.InGame.Utils;
using Events;
using UnityEngine;
using Zenject;

namespace InGame.Utils
{
    public class Projectile : EventBehaviour
    {
        [Inject] private GameSpeed _gameSpeed;

        [SerializeField] private GameObject _endObject;
        [SerializeField] private GameObject _startObject;
        [SerializeField] private float _speed = 5f;

        private Vector2 _targetPosition;
        private bool _hasReachedTarget = true;
        private int _indexProj;

        public void Open(Vector2 targetPosition, int indexProj)
        {
            _speed = _speed * _gameSpeed.GetGameSpeed();
            _targetPosition = targetPosition;
            _hasReachedTarget = false;
            _indexProj = indexProj;
        }

        private void Update()
        {
            if (_hasReachedTarget) return;
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _targetPosition) < 0.1f)
            {
                _hasReachedTarget = true;
                DispatchEvent("Done", _indexProj);
            }
        }

        public void Close()
        {
            if (_endObject != null)
            {
                _startObject.SetActive(false);
                _endObject.SetActive(true);
                Destroy(gameObject, 1f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
