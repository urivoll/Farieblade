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
        public async UniTask<ApiCallResult<GarageModel>> GetGarageByGarageId(string garageId)
        {
            var apiCallResult = new ApiCallResult<GarageModel>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Garages + garageId;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var restored = JsonConvert.DeserializeObject<GarageModel>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<GarageModel>>> GetListGarageByUserId(string userId)
        {
            var apiCallResult = new ApiCallResult<List<GarageModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Garages + ConnectionLink.Z + userId;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                }
                else
                {
                    var restored = JsonConvert.DeserializeObject<List<GarageModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<bool>> PutGarageModel(GarageModel garageModel)
        {
            var apiCallResult = new ApiCallResult<bool>();

            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Garages + garageModel.Id;
                Debug.Log("web request url: " + url);

                var jsonSerializeSettings = new JsonSerializerSettings() { DateFormatString = ConnectionLink.DateFormatString };
                var json = JsonConvert.SerializeObject(garageModel, jsonSerializeSettings);
                byte[] jsonByteArray = new UTF8Encoding().GetBytes(json);

                var request = UnityWebRequest.Put(url, jsonByteArray);
                request.uploadHandler = new UploadHandlerRaw(jsonByteArray);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("accept", "application/json");
                request.SetRequestHeader("Content-Type", "application/json");

                await request.SendWebRequest();
                Debug.Log("request.error: " + request.error);
                Debug.Log("request.result: " + request.result);

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
        
        
        public async UniTask<ApiCallResult<bool>> PostGarageModel(GarageModel garageModel)
        {
            try
            {
                var apiCallResult = new ApiCallResult<bool>();
                var url = ConnectionLink.Url + ConnectionLink.Garages;
                Debug.Log("web request url: " + url);

                var jsonSerializeSettings = new JsonSerializerSettings() { DateFormatString = ConnectionLink.DateFormatString };
                var json = JsonConvert.SerializeObject(garageModel, jsonSerializeSettings);
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
        
        public async UniTask<ApiCallResult<bool>> DeleteGarageModel(string garageId)
        {
            var  apiCallResult = new ApiCallResult<bool>();
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Garages + garageId;
                var request = UnityWebRequest.Delete(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    apiCallResult.ErrorMessage = "Network error";
                    apiCallResult.Data = false;
                    Debug.Log(request.error);
                }
                else apiCallResult.Data = true;
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