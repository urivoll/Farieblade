using System;
using System.Collections.Generic;
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
        public async UniTask<ApiCallResult<CommentsModel>> GetCommentByCommentsId(string commentsId)
        {
            var apiCallResult = new ApiCallResult<CommentsModel>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Comments + commentsId;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var restored = JsonConvert.DeserializeObject<CommentsModel>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<CommentsModel>>> GetListCommentByUserId(string userId)
        {
            var apiCallResult = new ApiCallResult<List<CommentsModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Comments + ConnectionLink.Z + userId;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var restored = JsonConvert.DeserializeObject<List<CommentsModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<CommentsModel>>> GetListCommentByCommentUserId(string commentUserId)
        {
            var apiCallResult = new ApiCallResult<List<CommentsModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Comments + ConnectionLink.Z + ConnectionLink.Z + commentUserId ;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var restored = JsonConvert.DeserializeObject<List<CommentsModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<bool>> PutCommentsModel(CommentsModel commentsModel)
        {
            var apiCallResult = new ApiCallResult<bool>();

            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Comments + commentsModel.Id;
                Debug.Log("web request url: " + url);

                var jsonSerializeSettings = new JsonSerializerSettings() { DateFormatString = ConnectionLink.DateFormatString };
                var json = JsonConvert.SerializeObject(commentsModel, jsonSerializeSettings);
                byte[] jsonByteArray = new UTF8Encoding().GetBytes(json);

                var request = UnityWebRequest.Put(url, jsonByteArray);
                request.uploadHandler = new UploadHandlerRaw(jsonByteArray);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("accept", "application/json");
                request.SetRequestHeader("Content-Type", "application/json");

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                    apiCallResult.Data = false;
                    Debug.Log(request.error);
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
        
        
        public async UniTask<ApiCallResult<bool>> PostCommentsModel(CommentsModel commentsModel)
        {
            try
            {
                var apiCallResult = new ApiCallResult<bool>();
                var url = ConnectionLink.Url + ConnectionLink.Comments;
                Debug.Log("web request url: " + url);

                var jsonSerializeSettings = new JsonSerializerSettings() { DateFormatString = ConnectionLink.DateFormatString };
                var json = JsonConvert.SerializeObject(commentsModel, jsonSerializeSettings);
                byte[] jsonByteArray = new UTF8Encoding().GetBytes(json);

                var request = new UnityWebRequest(url, "POST");

                request.uploadHandler = new UploadHandlerRaw(jsonByteArray);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("accept", "application/json");
                request.SetRequestHeader("Content-Type", "application/json");

                await request.SendWebRequest();
                
                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                    apiCallResult.Data = false;
                    Debug.Log(request.error);
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
        
        public async UniTask<ApiCallResult<bool>> DeleteCommentsModel(string commentsId)
        {
            var  apiCallResult = new ApiCallResult<bool>();
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Comments + commentsId;
                var request = UnityWebRequest.Delete(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                    apiCallResult.Data = false;
                    Debug.Log(request.error);
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