using System;
using Events;
using Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;
using Cysharp.Threading.Tasks;
using Core.Screens.Controller.PopUp;

namespace Server
{
    public partial class RequestBuilder : EventDispatcher
    {
        private MessageBoxController _messageBoxManager;
        
        [Inject]
        private void Construct(MessageBoxController messageBoxManager)
        {
            _messageBoxManager = messageBoxManager;
        }
        
        
        public async UniTask<ApiCallResult<string>> SendSmsRequest(string userNumber)
        {
            var apiCallResult = new ApiCallResult<string>();
            var confirmNumber = UnityEngine.Random.Range(1000, 9999);
            try
            {
                //if (!Application.isEditor)
                if (false)
                {
                    var url = "https://smsc.ru/sys/send.php?login=syberia&psw=K1e2s3k4i5l6&phones=" + userNumber + "&mes=" + confirmNumber.ToString();
                    var request = UnityWebRequest.Get(url);
                    Debug.Log("web request url: " + url);
                
                    await request.SendWebRequest();
                    Debug.Log("SendSMSRequest - result: " + request.result + ". code: " + request.responseCode);

                    if (request.isNetworkError || request.isHttpError)
                    {
                        apiCallResult.ErrorMessage = "Network error";
                    }
                    else
                    {
                        apiCallResult.Data = confirmNumber.ToString();
                    }
                    return apiCallResult;
                }
                else
                {              
                    apiCallResult.Data = confirmNumber.ToString();
                    return apiCallResult;
                }                       
            }
            catch (Exception)
            {
                _messageBoxManager.OpenInfo("Error", "Проблемы с интернетом");
                throw;
            }
        }
       
        public async UniTask<ApiCallResult<AppVersionsModel>> GetAppVersion()
        {
            var apiCallResult = new ApiCallResult<AppVersionsModel>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.AppVersions;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();            

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var appVersionModel = JsonConvert.DeserializeObject<AppVersionsModel>(request.downloadHandler.text);
                    apiCallResult.Data = appVersionModel;
                    Debug.Log("Request: " + request.downloadHandler.text);
                }
                return apiCallResult;
            }
            catch (Exception)
            {            
                _messageBoxManager.OpenInfo("Error", "Проблемы с интернетом");
                throw;
            }
        }

        public async UniTask<ApiCallResult<DateTimeModel>> GetDateTime()
        {
            var apiCallResult = new ApiCallResult<DateTimeModel>();

            try
            {
                var url = ConnectionLink.Url + ConnectionLink.DateTime;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var TimeNow = JsonConvert.DeserializeObject<DateTimeModel>(request.downloadHandler.text);
                    apiCallResult.Data = TimeNow;
                    Debug.Log("Request: " + request.downloadHandler.text);
                }
                return apiCallResult;
            }
            catch (Exception)
            {
                _messageBoxManager.OpenInfo("Error", "Проблемы с интернетом");
                throw;
            }
        }
    }
}
