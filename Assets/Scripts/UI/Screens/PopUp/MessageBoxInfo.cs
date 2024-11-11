using System;
using Events;
using TMPro;
using UI.UIElement;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.PopUp
{
    public class MessageBoxInfo : EventBehaviour
    {
        [SerializeField] private TextMeshProUGUI headerTxt;
        [SerializeField] private TextMeshProUGUI messageTxt;
        [SerializeField] private Button okButton;
        
        private Action _closeCallback;

        public void Open(string header, string text, Action closeCallback = null)
        {
            headerTxt.text = header;
            messageTxt.text = text;
            _closeCallback = closeCallback;
            
            okButton.onClick.AddListener(OkButton);
        }

        private void OkButton()
        {
            _closeCallback?.Invoke();
            OnDestroy();
        }
        
        private void OnDestroy()
        {
            _closeCallback = null;
            okButton.onClick.RemoveListener(OkButton);
            Destroy(gameObject);
        }
    
        public class Factory : UIFactory<MessageBoxInfo>{}
    }
}