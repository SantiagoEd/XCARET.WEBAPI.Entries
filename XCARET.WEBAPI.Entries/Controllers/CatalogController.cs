using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using XCARET.WEBAPI.Entries.Business;
using XCARET.WEBAPI.Entries.Crosscuting.Interface;
using XCARET.WEBAPI.Entries.Entities.Response;
using static System.Net.WebRequestMethods;

namespace XCARET.WEBAPI.Entries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IProcessItemBusiness _processItemBusiness;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(IProcessItemBusiness processItemBusiness, ILogger<CatalogController> logger) 
        {
            _processItemBusiness = processItemBusiness;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetEntriesByHttps/{Https}")]
        public async Task<ResponseBase<ResponseEntries>> getEntriesbyHttps(bool Https) 
        {
            try
            {
                return await _processItemBusiness.getEntriesbyHttps(Https);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResponseBase<ResponseEntries>{ Success = false, Message = "Fallo con el servidor, contacte al administrador" };
            }
        }

        [HttpGet]
        [Route("GetEntriesByCategory")]
        public async Task<ResponseBase<ResponseEntries>> getEntriesbyCategory()
        {
            try
            {
                return await _processItemBusiness.getEntriesbyCategory();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResponseBase<ResponseEntries> { Success = false, Message = "Fallo con el servidor, contacte al administrador" };
            }
        }
    }
}
