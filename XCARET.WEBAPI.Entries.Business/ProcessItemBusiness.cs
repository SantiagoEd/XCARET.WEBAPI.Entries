using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCARET.WEBAPI.Entries.Crosscuting.Interface;
using XCARET.WEBAPI.Entries.Entities.Response;
using static System.Net.WebRequestMethods;

namespace XCARET.WEBAPI.Entries.Business
{
    public class ProcessItemBusiness : IProcessItemBusiness
    {
        IRestApiConsumer _apiConsumer;
        public ProcessItemBusiness(IRestApiConsumer apiConsumer) 
        {
            _apiConsumer = apiConsumer;
        }

        public async Task<ResponseBase<ResponseEntries>> getEntriesbyCategory()
        {
            var response = new ResponseBase<ResponseEntries>();
            try
            {
                response.Success = true;
                response.Message = "Proceso ejecutado correctamente";
                var consumeEntries = await _apiConsumer.Consume<ResponseEntries>($"entries", null, RestSharp.Method.Get);
                var lstEntries = consumeEntries.entries.GroupBy(x => x.Category, (key, group) => group.First()).ToList();
                response.Data = new ResponseEntries
                {
                    count = lstEntries.Count,
                    entries = lstEntries
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.StackTrace}-{ex.Message}");
            }
            return response;
        }

        public async Task<ResponseBase<ResponseEntries>> getEntriesbyHttps(bool https)
        {
            var response = new ResponseBase<ResponseEntries>();
            try 
            {
                response.Success = true;
                response.Message = "Proceso ejecutado correctamente";
                var consumeEntries = await _apiConsumer.Consume<ResponseEntries>($"entries", null, RestSharp.Method.Get);
                var lstEntries = consumeEntries.entries.Where(w => w.HTTPS == https).ToList();
                response.Data = new ResponseEntries 
                {
                    count = lstEntries.Count,
                    entries = lstEntries
                };
            }
            catch(Exception ex) 
            {
                throw new Exception($"{ex.StackTrace}-{ex.Message}");
            }
            return response;
        }
    }
}
