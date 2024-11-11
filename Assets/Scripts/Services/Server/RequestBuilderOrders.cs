using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
        public async UniTask<ApiCallResult<OrderModel>> GetOrderByOrderId(string orderId)
        {
            var apiCallResult = new ApiCallResult<OrderModel>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + orderId;
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
                    var restored = JsonConvert.DeserializeObject<OrderModel>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<OrderModel>>> GetListOrderByUserId (string userId)
        {
            var apiCallResult = new ApiCallResult<List<OrderModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + ConnectionLink.Z + userId;
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
                    var restored = JsonConvert.DeserializeObject<List<OrderModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<OrderModel>>> GetListOrderByOrderId (string orderId)
        {
            var apiCallResult = new ApiCallResult<List<OrderModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + ConnectionLink.Z + ConnectionLink.Z + orderId;
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
                    var restored = JsonConvert.DeserializeObject<List<OrderModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<OrderModel>>> GetListOrderByAgreementId (string agreementId)
        {
            var apiCallResult = new ApiCallResult<List<OrderModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + ConnectionLink.Z + ConnectionLink.Z + ConnectionLink.Z + agreementId;
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
                    var restored = JsonConvert.DeserializeObject<List<OrderModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<OrderModel>>> GetListOrderByPage (int page, int pageSize)
        {
            var apiCallResult = new ApiCallResult<List<OrderModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + ConnectionLink.Z + ConnectionLink.Z + ConnectionLink.Z + page + "/" + pageSize;
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
                    var restored = JsonConvert.DeserializeObject<List<OrderModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<OrderModel>>> GetListOrderByPageByState (int page, int pageSize, string state)
        {
            var apiCallResult = new ApiCallResult<List<OrderModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + ConnectionLink.Z + ConnectionLink.Z + ConnectionLink.Z + page + "/" + pageSize + "/" + state;
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
                    var restored = JsonConvert.DeserializeObject<List<OrderModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<OrderModel>>> GetListOrderByPageByStateById (string state, string id)
        {
            var apiCallResult = new ApiCallResult<List<OrderModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + ConnectionLink.Z + ConnectionLink.Z + ConnectionLink.Z + ConnectionLink.Z + ConnectionLink.Z + state + "/" + id;
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
                    var restored = JsonConvert.DeserializeObject<List<OrderModel>>(request.downloadHandler.text);
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
        
        public async UniTask<ApiCallResult<List<OrderModel>>> GetListOrderBySearch (
            string regionFrom, string cityFrom, string regionTo, string cityTo, string cargoType, 
            string bodyType, string weight, string state, string volume, int page, int pageSize)
        {
            var slash = "/";
            var apiCallResult = new ApiCallResult<List<OrderModel>>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + regionFrom +slash+ cityFrom +slash+ regionTo +slash+ cityTo +slash+ state + slash + weight + slash + bodyType + slash + volume + slash + cargoType + slash + page + slash + pageSize;
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
                    var restored = JsonConvert.DeserializeObject<List<OrderModel>>(request.downloadHandler.text);
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

        public async UniTask<ApiCallResult<bool>> PutOrderModel(OrderModel orderModel)
        {
            var apiCallResult = new ApiCallResult<bool>();

            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + orderModel.Id;
                Debug.Log("web request url: " + url);

                var jsonSerializeSettings = new JsonSerializerSettings() { DateFormatString = ConnectionLink.DateFormatString };
                var json = JsonConvert.SerializeObject(orderModel, jsonSerializeSettings);
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
        
        
        public async UniTask<ApiCallResult<bool>> PostOrderModel(OrderModel orderModel)
        {
            var apiCallResult = new ApiCallResult<bool>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order;
                Debug.Log("web request url: " + url);

                var jsonSerializeSettings = new JsonSerializerSettings() { DateFormatString = ConnectionLink.DateFormatString };
                var json = JsonConvert.SerializeObject(orderModel, jsonSerializeSettings);
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
        
        public async UniTask<ApiCallResult<bool>> DeleteOrderModel(string orderId)
        {
            var  apiCallResult = new ApiCallResult<bool>();
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Order + orderId;
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
            catch (Exception ex)
            {
                _messageBoxManager.OpenInfo("Error", ex.Message);
                throw;
            }
        }
    }
}