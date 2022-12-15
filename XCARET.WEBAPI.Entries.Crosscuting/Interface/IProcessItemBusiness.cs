using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XCARET.WEBAPI.Entries.Entities.Response;

namespace XCARET.WEBAPI.Entries.Crosscuting.Interface
{
    public interface IProcessItemBusiness
    {
        Task<ResponseBase<ResponseEntries>> getEntriesbyHttps(bool https);

        Task<ResponseBase<ResponseEntries>> getEntriesbyCategory();
    }
}
