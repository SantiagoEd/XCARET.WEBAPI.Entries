using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XCARET.WEBAPI.Entries.Crosscuting.Interface;

namespace XCARET.WEBAPI.Entries.Business.Services
{
    public class RestApiConsumer : IRestApiConsumer
    {
        public readonly RestClient _restClient;

        public RestApiConsumer(string Url) 
        {
            if (string.IsNullOrEmpty(Url)) { throw new ArgumentNullException(nameof(Url)); }
            _restClient = new RestClient(Url);
        }
        public IAuthenticator authenticator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<TResponse> Consume<TResponse>(string action, object request, RestSharp.Method method = Method.Get) where TResponse : new()
        {
            var restRequest = new RestRequest(action, method);
            if(request != null) { restRequest.AddJsonBody(request); }
            restRequest.Timeout = 60000;
            
            var restResponse = _restClient.Execute<TResponse>(restRequest);

            if(restResponse.ErrorException != null) { throw new Exception(restResponse.ErrorException.Message); }

            return restResponse.Data;
        }
    }
}
