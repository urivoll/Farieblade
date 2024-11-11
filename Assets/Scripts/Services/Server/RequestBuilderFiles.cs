using System;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Server
{
    public partial class RequestBuilder
    {
        public async Task<ApiCallResult<OrderModel>> GetFiles(string fileName)
        {
            var apiCallResult = new ApiCallResult<OrderModel>();
            
            try
            {
                var url = ConnectionLink.Url + ConnectionLink.Files + fileName;
                var request = UnityWebRequest.Get(url);
                Debug.Log("web request url: " + url);

                await request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
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
        
        public async Task<ApiCallResult<bool>> PostFiles(OrderModel orderModel)//(IFormFile orderModel)
        {
            try
            {
                var apiCallResult = new ApiCallResult<bool>();
                var url = ConnectionLink.Url + ConnectionLink.Files;
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
    }
}