using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOrderItemsApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        void AddItem (int? orderId, AddItemRequest item);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        void ClearOrderItems (int? orderId);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>List&lt;OrderItemResponse&gt;</returns>
        List<OrderItemResponse> GetItems (int? orderId);
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        void Ping ();
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        void RemoveItem (int? orderId, int? itemId);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        void UpdateItemQuantity (int? orderId, int? itemId, int? quantity);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class OrderItemsApi : IOrderItemsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public OrderItemsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OrderItemsApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param> 
        /// <param name="item"></param> 
        /// <returns></returns>            
        public void AddItem (int? orderId, AddItemRequest item)
        {
            
            // verify the required parameter 'orderId' is set
            if (orderId == null) throw new ApiException(400, "Missing required parameter 'orderId' when calling AddItem");
            
    
            var path = "/api/OrderItems/orders/{orderId}/items";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "orderId" + "}", ApiClient.ParameterToString(orderId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(item); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling AddItem: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling AddItem: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param> 
        /// <returns></returns>            
        public void ClearOrderItems (int? orderId)
        {
            
            // verify the required parameter 'orderId' is set
            if (orderId == null) throw new ApiException(400, "Missing required parameter 'orderId' when calling ClearOrderItems");
            
    
            var path = "/api/OrderItems/orders/{orderId}/items";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "orderId" + "}", ApiClient.ParameterToString(orderId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ClearOrderItems: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ClearOrderItems: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param> 
        /// <returns>List&lt;OrderItemResponse&gt;</returns>            
        public List<OrderItemResponse> GetItems (int? orderId)
        {
            
            // verify the required parameter 'orderId' is set
            if (orderId == null) throw new ApiException(400, "Missing required parameter 'orderId' when calling GetItems");
            
    
            var path = "/api/OrderItems/orders/{orderId}/items";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "orderId" + "}", ApiClient.ParameterToString(orderId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetItems: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetItems: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<OrderItemResponse>) ApiClient.Deserialize(response.Content, typeof(List<OrderItemResponse>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>            
        public void Ping ()
        {
            
    
            var path = "/api/OrderItems/ping";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Ping: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Ping: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param> 
        /// <param name="itemId"></param> 
        /// <returns></returns>            
        public void RemoveItem (int? orderId, int? itemId)
        {
            
            // verify the required parameter 'orderId' is set
            if (orderId == null) throw new ApiException(400, "Missing required parameter 'orderId' when calling RemoveItem");
            
            // verify the required parameter 'itemId' is set
            if (itemId == null) throw new ApiException(400, "Missing required parameter 'itemId' when calling RemoveItem");
            
    
            var path = "/api/OrderItems/orders/{orderId}/items/{itemId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "orderId" + "}", ApiClient.ParameterToString(orderId));
path = path.Replace("{" + "itemId" + "}", ApiClient.ParameterToString(itemId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveItem: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveItem: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="orderId"></param> 
        /// <param name="itemId"></param> 
        /// <param name="quantity"></param> 
        /// <returns></returns>            
        public void UpdateItemQuantity (int? orderId, int? itemId, int? quantity)
        {
            
            // verify the required parameter 'orderId' is set
            if (orderId == null) throw new ApiException(400, "Missing required parameter 'orderId' when calling UpdateItemQuantity");
            
            // verify the required parameter 'itemId' is set
            if (itemId == null) throw new ApiException(400, "Missing required parameter 'itemId' when calling UpdateItemQuantity");
            
            // verify the required parameter 'quantity' is set
            if (quantity == null) throw new ApiException(400, "Missing required parameter 'quantity' when calling UpdateItemQuantity");
            
    
            var path = "/api/OrderItems/orders/{orderId}/items/{itemId}/quantity/{quantity}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "orderId" + "}", ApiClient.ParameterToString(orderId));
path = path.Replace("{" + "itemId" + "}", ApiClient.ParameterToString(itemId));
path = path.Replace("{" + "quantity" + "}", ApiClient.ParameterToString(quantity));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateItemQuantity: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateItemQuantity: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
