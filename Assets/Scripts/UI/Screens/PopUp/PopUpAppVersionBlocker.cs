using Events;
using TMPro;
using UI.UIElement;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.PopUp
{
    public class PopUpAppVersionBlocker : EventBehaviour
    {
        [SerializeField] private TextMeshProUGUI headerTxt;
        [SerializeField] private TextMeshProUGUI messageTxt;
        [SerializeField] private TextMeshProUGUI buttonTxt;
        [SerializeField] private Button okButton;
        
        public void Open(string header, string text, string button)
        {
            headerTxt.text = header;
            messageTxt.text = text;
            buttonTxt.text = button;
            
            okButton.onClick.AddListener(OkButton);
        }

        private void OkButton()
        {
            Application.OpenURL("market://details?id=" + Application.productName);
        }
        
        private void OnDestroy()
        {
            okButton.onClick.RemoveListener(OkButton);
            Destroy(gameObject);
        }
    
        public class Factory : UIFactory<PopUpAppVersionBlocker>{}
    }
}
