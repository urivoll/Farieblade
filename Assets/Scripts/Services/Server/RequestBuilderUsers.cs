using System;
using System.Text;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Server
{
    public partial class RequestBuilder
    {
        public async UniTask<ApiCallResult<UserModel>> GetUserByUserId(string userId )
        {
            var apiCallResult = new ApiCallResult<UserModel>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Users + userId;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log("Request error: " + request.error);
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var restored = JsonConvert.DeserializeObject<UserModel>(request.downloadHandler.text);
                    apiCallResult.Data = restored;
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
        
        public async UniTask<ApiCallResult<UserModel>> GetUserByPhone(string phone)
        {
            var apiCallResult = new ApiCallResult<UserModel>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Users + ConnectionLink.Z + phone;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log("Request error: " + request.error);
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var restored = JsonConvert.DeserializeObject<UserModel>(request.downloadHandler.text);
                    apiCallResult.Data = restored;
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

        [Obsolete]
        public async UniTask<ApiCallResult<bool>> PutUserModel(UserModel userModel)
        {
            var apiCallResult = new ApiCallResult<bool>();

            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Users + userModel.Id;
                Debug.Log("web request url: " + url);

                var jsonSerializeSettings = new JsonSerializerSettings() { DateFormatString = ConnectionLink.DateFormatString };
                var json = JsonConvert.SerializeObject(userModel, jsonSerializeSettings);
                byte[] jsonByteArray = new UTF8Encoding().GetBytes(json);

                var request = UnityWebRequest.Put(url, jsonByteArray);
                request.uploadHandler = new UploadHandlerRaw(jsonByteArray);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("accept", "application/json");
                request.SetRequestHeader("Content-Type", "application/json");

                await request.SendWebRequest();
                
                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log("Request error: " + request.error);
                    apiCallResult.ErrorMessage = "Network error";
                    apiCallResult.Data = false;
                }
                else
                {
                    apiCallResult.Data = true;
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
        
        
        public async UniTask<ApiCallResult<bool>> PostUserModel(UserModel userModel)
        {
            try
            {
                var apiCallResult = new ApiCallResult<bool>();
                var url = ConnectionLink.Url + ConnectionLink.Users;
                Debug.Log("web request url: " + url);

                var jsonSerializeSettings = new JsonSerializerSettings() { DateFormatString = ConnectionLink.DateFormatString };
                var json = JsonConvert.SerializeObject(userModel, jsonSerializeSettings);
                byte[] jsonByteArray = new UTF8Encoding().GetBytes(json);

                var request = new UnityWebRequest(url, "POST");

                request.uploadHandler = new UploadHandlerRaw(jsonByteArray);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("accept", "application/json");
                request.SetRequestHeader("Content-Type", "application/json");

                await request.SendWebRequest();
                
                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log("Request error: " + request.error);
                    apiCallResult.ErrorMessage = "Network error";
                    apiCallResult.Data = false;
                }
                else
                {
                    apiCallResult.Data = true;
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
        
        public async UniTask<ApiCallResult<bool>> DeleteUserModel(string userId)
        {
            var  apiCallResult = new ApiCallResult<bool>();
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Users + userId;
                var request = UnityWebRequest.Delete(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log("Request error: " + request.error);
                    apiCallResult.ErrorMessage = "Network error";
                    apiCallResult.Data = false;
                }
                else
                {
                    apiCallResult.Data = true;
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