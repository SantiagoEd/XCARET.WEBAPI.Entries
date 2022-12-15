using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XCARET.WEBAPI.Entries.Crosscuting.Interface
{
    public interface IRestApiConsumer
    {
        IAuthenticator authenticator { set; get; }
        Task<TResponse> Consume<TResponse>(string action, object request, RestSharp.Method method) where TResponse : new();
    }
}
