using System;
using Events;
using TMPro;
using UI.UIElement;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.PopUp
{
    public class MessageBoxDialog : EventBehaviour
    {
        [SerializeField] private TextMeshProUGUI headerTxt;
        [SerializeField] private TextMeshProUGUI messageTxt;
        [SerializeField] private Button okButton;
        [SerializeField] private Button cancelButton;

        private Action _okButtonCallback;
        private Action _cancelButtonCallback;

        public void Open(string header, string message, Action okCallback = null, Action cancelCallback = null)
        {
            headerTxt.text = header;
            messageTxt.text = message;
            _okButtonCallback = okCallback;
            _cancelButtonCallback = cancelCallback;
            
            okButton.onClick.AddListener(OkButton);
            cancelButton.onClick.AddListener(CancelButton);
        }

        private void OkButton()
        {
            _okButtonCallback?.Invoke();
            OnDestroy();
        }

        private void CancelButton()
        {
            _cancelButtonCallback?.Invoke();
            OnDestroy();
        }
        
        private void OnDestroy()
        {
            _okButtonCallback = null;
            _cancelButtonCallback = null;
            okButton.onClick.RemoveListener(OkButton);
            cancelButton.onClick.RemoveListener(CancelButton);
            Destroy(gameObject);
        }
    
        public class Factory : UIFactory<MessageBoxDialog>{}
    }
}