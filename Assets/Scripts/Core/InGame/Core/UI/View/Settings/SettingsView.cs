using Core.InGame.Controller;
using Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.InGame.UI.View
{
    public class SettingsView : EventBehaviour
    {
        [SerializeField] private Sprite[] _aiSprites;
        [SerializeField] private Image _aiImage;
        [SerializeField] private Sprite[] _viewSprites;
        [SerializeField] private Image _viewImage;
        [SerializeField] private Button _aiButton;
        [SerializeField] private Button _viewButton;
        [SerializeField] private Button _sidePanelButton;
        [SerializeField] private Button _sidePanelBlackBGButton;
        [SerializeField] private GameObject _sidePanel;

        [Inject] private SoundController _soundController;

        private bool _ai;
        private int _view;

        public void Open(bool ai, int view)
        {
            _ai = ai;
            _view = view;
            RefreshButtons();
            _aiButton.onClick.AddListener(ChangeAi);
            _viewButton.onClick.AddListener(ChangeView);
            _sidePanelButton.onClick.AddListener(ShowSidePanel);
            _sidePanelBlackBGButton.onClick.AddListener(ShowSidePanel);
        }

        public void OnDestroy()
        {
            _aiButton.onClick.RemoveListener(ChangeAi);
            _viewButton.onClick.RemoveListener(ChangeView);
            _sidePanelButton.onClick.RemoveListener(ShowSidePanel);
            _sidePanelBlackBGButton.onClick.RemoveListener(ShowSidePanel);
        }

        private void ShowSidePanel()
        {
            _soundController.PlayClickSound(0);
            _sidePanel.SetActive(_sidePanel.activeSelf ? false : true);
        }

        private void ChangeAi()
        {
            _ai = _ai ? false : true;
            DispatchEvent("Change ai", _ai);
            Refresh();
        }

        private void ChangeView()
        {
            _view = (_view == 0) ? 1 : 0;
            DispatchEvent("Change view", _view);
            Refresh();
        }

        private void Refresh() 
        {
            RefreshButtons();
            ShowSidePanel();
        }

        public void RefreshButtons()
        {
            _aiImage.sprite = (_ai) ? _aiSprites[1] : _aiSprites[0];
            _viewImage.sprite = (_view == 0) ? _viewSprites[0] : _viewSprites[1];
        }
    }
}