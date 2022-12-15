using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XCARET.WEBAPI.Entries.Entities.Response
{
    public class ResponseBase<T> where T: new()
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; } 
    }
}
