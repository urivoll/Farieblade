using System;
using Events;
using TMPro;
using UI.UIElement;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.PopUp
{
    public class MessageBoxNeutral : EventBehaviour
    {
        [SerializeField] private TextMeshProUGUI headerTxt;
        [SerializeField] private TextMeshProUGUI messageTxt;
        [SerializeField] private Button okButton;
        [SerializeField] private Button cancelButton;
        [SerializeField] private Button neutralButton;

        private Action _okCallback;
        private Action _cancelCallback;
        private Action _neutralCallback;

        public void Open(string header, string message, Action okCallback = null, Action cancelCallback = null, Action neutralCallback = null)
        {
            headerTxt.text = header;
            messageTxt.text = message;
            _okCallback = okCallback;
            _cancelCallback = cancelCallback;
            _neutralCallback = neutralCallback;
            
            okButton.onClick.AddListener(OkButton);
            cancelButton.onClick.AddListener(CancelButton);
            neutralButton.onClick.AddListener(NeutralButton);
        }

        private void OkButton()
        {
            _okCallback?.Invoke();
            OnDestroy();
        }

        private void CancelButton()
        {
            _cancelCallback?.Invoke();
            OnDestroy();
        }

        private void NeutralButton()
        {
            _neutralCallback?.Invoke();
            OnDestroy();
        }
        
        public void OnDestroy()
        {
            _okCallback = null;
            _cancelCallback = null;
            _neutralCallback = null;
            okButton.onClick.RemoveListener(OkButton);
            cancelButton.onClick.RemoveListener(CancelButton);
            neutralButton.onClick.RemoveListener(NeutralButton);
            Destroy(gameObject);
        }
    
        public class Factory : UIFactory<MessageBoxNeutral>{}
    }
}
