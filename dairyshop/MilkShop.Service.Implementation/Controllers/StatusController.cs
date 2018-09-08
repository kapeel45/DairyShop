using MilkShop.Business.Contract;
using MilkShop.Business.Implementation;
using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MilkShop.Service.Implementation.Controllers
{
    public class StatusController : ApiController
    { 
        IStatusManager istatusManager = new StatusManager();
        [Route("status")]
        [HttpGet]
        public APIResponse GetAllitem()
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = istatusManager.GetAllStatus();
                response.Success = true;
                response.Error = null;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }
    }
}
