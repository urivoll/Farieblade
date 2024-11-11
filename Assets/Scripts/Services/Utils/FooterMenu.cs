using UnityEngine;

namespace foot
{
    public class FooterMenu : MonoBehaviour
    {
        [SerializeField] private RectTransform[] _gameObject;

        public void ShowCircle(int index)
        {
            for (int i = 0; i < _gameObject.Length; i++)
            {
                _gameObject[i].gameObject.SetActive(false);
                //_gameObject[i].position = new(_gameObject[i].position.x, 0, 0);
            }
            _gameObject[index].gameObject.SetActive(true);
            //_gameObject[index].position = new(_gameObject[index].position.x, 20, 0);
        }
    }

}
