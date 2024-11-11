using Data;
using Events;
using Models;
using Server;
using Zenject;

namespace UI.Manager
{
	public class RegistrationManager : EventDispatcher
	{/*
		private UserData _userData;
		private RequestBuilder _requestBuilder;
		private MessageBoxManager _messageBoxManager;
			
		private RegistrationScreen _registrationScreen;
		private RegistrationScreenSms _registrationScreenSms;
		private RegistrationScreenField _registrationScreenField;
		
		private RegistrationScreen.Factory _registrationScreenFactory;
		private RegistrationScreenSms.Factory _registrationScreenSmsFactory;
		private RegistrationScreenField.Factory _registrationScreenFieldFactory;
      
		
		[Inject]
        private void Construct(
	        UserData userData,
	        RequestBuilder requestBuilder,
	        MessageBoxManager messageBoxManager,
            RegistrationScreen.Factory registrationScreenFactory,
            RegistrationScreenSms.Factory registrationScreenSmsFactory,
            RegistrationScreenField.Factory registrationScreenFieldFactory
            )
        {
	        _userData = userData;
	        _requestBuilder = requestBuilder;
	        _messageBoxManager = messageBoxManager;
            _registrationScreenFactory = registrationScreenFactory;
            _registrationScreenSmsFactory = registrationScreenSmsFactory;
            _registrationScreenFieldFactory = registrationScreenFieldFactory;
        }

		
		public void Open()
		{     
			_registrationScreen = _registrationScreenFactory.Create();
			_registrationScreen.AddListener(ManagerEvents.OnClick, ScreenSms);
			_registrationScreen.Open();
		}
		
		private void ScreenSms(EventArgs evt)
		{
			var codeTxt = (string)evt.args[0];
			var phoneTxt = (string)evt.args[1];
			
			_registrationScreenSms = _registrationScreenSmsFactory.Create();
			_registrationScreenSms.Open(codeTxt, phoneTxt);
			_registrationScreenSms.AddListener(ManagerEvents.CodeСonfirmed, CheckRegistrationWithOldUser);
			_registrationScreenSms.AddListener(ManagerEvents.OnClickBack, BackScreenSms);
			
			_registrationScreen.RemoveListener(ManagerEvents.OnClick, ScreenSms);
			_registrationScreen.OnDestroy();
		}
		
		private void BackScreenSms(EventArgs evt)
		{    
			_registrationScreen = _registrationScreenFactory.Create();
			_registrationScreen.AddListener(ManagerEvents.OnClick, ScreenSms);
			_registrationScreen.Open();
			
			_registrationScreenSms.RemoveListener(ManagerEvents.CodeСonfirmed, CheckRegistrationWithOldUser);
			_registrationScreenSms.RemoveListener(ManagerEvents.OnClickBack, BackScreenSms);
			_registrationScreenSms.OnDestroy();
		}

		private async void CheckRegistrationWithOldUser(EventArgs evt)
		{
			_registrationScreenSms.RemoveListener(ManagerEvents.CodeСonfirmed, CheckRegistrationWithOldUser);
			_registrationScreenSms.RemoveListener(ManagerEvents.OnClickBack, BackScreenSms);
			_registrationScreenSms.OnDestroy();
			
			var phoneTxt = (string)evt.args[0];
			var apiCallResult = await _requestBuilder.GetUserByPhone(phoneTxt);
            
			if (string.IsNullOrEmpty(apiCallResult.ErrorMessage) == false)
			{
				_messageBoxManager.OpenInfo(_messageBoxManager.DefaultErrorHeader, apiCallResult.ErrorMessage);
			}
			else
			{
				var userModel = apiCallResult.Data;
				if (userModel != null)
				{
					CompleteRegistrationWithOldUser(apiCallResult.Data);  
					return;
				}
			}

			ScreenField(phoneTxt);
		}
		
		private void ScreenField(string phoneTxt)
		{
			_registrationScreenField = _registrationScreenFieldFactory.Create();
			_registrationScreenField.AddListener(ManagerEvents.RegistrationComplete, RegistrationComplete);
			_registrationScreenField.Open(phoneTxt);
		}

		private void RegistrationComplete(EventArgs evt)
		{
			_registrationScreenField.RemoveListener(ManagerEvents.RegistrationComplete, RegistrationComplete);
			_registrationScreenField.OnDestroy();
			
			DispatchEvent(ManagerEvents.RegistrationComplete);
		}
		
		private void CompleteRegistrationWithOldUser(UserModel userModel)
		{
			_userData.SetUserModelOfUser(userModel);
			_userData.SetSavedPhone(userModel.Phone);
			_userData.SetUserEverCreated();
			DispatchEvent(ManagerEvents.RegistrationComplete);
		}*/
	}
}
