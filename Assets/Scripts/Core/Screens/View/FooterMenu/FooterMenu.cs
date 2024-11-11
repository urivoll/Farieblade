using Events;
using UI.Manager;
using UI.UIElement;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace Core.Screens.View.FooterMenu
{
    public class FooterMenu : EventBehaviour
    {
        [SerializeField] private Image[] _buttonsImg;
        [SerializeField] private Sprite[] _nonActiveSprite;
        [SerializeField] private Sprite[] _activeSprite;
        [SerializeField] private Button[] _buttons;

        private void Start()
        {
            for (int i = 0; i < _buttonsImg.Length; i++)
            {
                int index = i;
                _buttons[i].onClick.AddListener(() => OnClick(index));
            }
        }

        public void Open(int index = 0)
        {
            transform.SetSiblingIndex(2);
            ChangeImageButtons(index);
        }

        private void ChangeImageButtons(int position)
        {
            for (int i = 0; i < _buttonsImg.Length; i++)
            {
                if (i == position)
                {
                    _buttons[i].interactable = false;
                    _buttonsImg[i].sprite = _activeSprite[i];
                    continue;
                }
                _buttons[i].interactable = true;
                _buttonsImg[i].sprite = _nonActiveSprite[i];
            }
        }

        private void OnClick(int index)
        {
            ChangeImageButtons(index);
            DispatchEvent(EventManager.OnClick, index);
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].onClick.RemoveListener(() => OnClick(i));
            }
            Destroy(gameObject);
        }

        public class Factory : UIFactory<FooterMenu> { }
    }
}