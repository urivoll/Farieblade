using System;
using UI.Screens.PopUp;
using Zenject;

namespace Core.Screens.Controller.PopUp
{
    public class MessageBoxController
    {
        private MessageBoxInfo _messageBoxInfo;
        private MessageBoxDialog _messageBoxDialog;
        private MessageBoxNeutral _messageBoxNeutral;
        private PopUpNotification _popUpNotification;
        private PopUpAppVersionBlocker _popUpAppVersionBlocker;
        
        private MessageBoxInfo.Factory _messageBoxInfoFactory;
        private MessageBoxDialog.Factory _messageBoxDialogFactory;
        private MessageBoxNeutral.Factory _messageBoxNeutralFactory;
        private PopUpNotification.Factory _popUpNotificationFactory;
        private PopUpAppVersionBlocker.Factory _popUpBlockFactory;

        public string DefaultErrorHeader => "Ошибка";
        public string DefaultAttention => "Внимание";
        public string DefaultInfoHeader => "Сведение";
        
        
        [Inject]
        private void Construct(MessageBoxInfo.Factory messageBoxInfoFactory, 
            MessageBoxDialog.Factory messageBoxDialogFactory, 
            MessageBoxNeutral.Factory messageBoxNeutralFactory,
            PopUpNotification.Factory popUpNotificationFactory,
            PopUpAppVersionBlocker.Factory popUpBlockFactory)
        {
            _messageBoxInfoFactory = messageBoxInfoFactory;
            _messageBoxDialogFactory = messageBoxDialogFactory;
            _messageBoxNeutralFactory = messageBoxNeutralFactory;
            _popUpNotificationFactory = popUpNotificationFactory;
            _popUpBlockFactory = popUpBlockFactory;
        }

        public void OpenInfo(string header, string message, Action closeCallback = null)
        {
            _messageBoxInfo = _messageBoxInfoFactory.Create();
            _messageBoxInfo.Open(header, message, closeCallback);        
        }

        public void OpenDialogConfirm(string header, string message, Action okCallback = null, Action cancelCallback = null)
        {
            _messageBoxDialog = _messageBoxDialogFactory.Create();
            _messageBoxDialog.Open(header, message, okCallback, cancelCallback);                
        }

        public void OpenDialogNeutral(string header, string message, Action okCallback = null, Action cancelCallback = null, Action neutralCallback = null)
        {
            _messageBoxNeutral = _messageBoxNeutralFactory.Create();
            _messageBoxNeutral.Open(header, message, okCallback, cancelCallback, neutralCallback);
        }
        
        public void OpenPopUpNotification(string header, string message, Action closeCallback = null)
        {
            _popUpNotification = _popUpNotificationFactory.Create();
            _popUpNotification.Open(header, message, closeCallback);        
        }
        
        public void OpenPopUpBlock(string header, string message, string button)
        {
            _popUpAppVersionBlocker = _popUpBlockFactory.Create();
            _popUpAppVersionBlocker.Open(header, message, button);        
        }
    }
}
