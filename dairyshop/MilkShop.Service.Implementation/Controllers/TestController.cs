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
    public class TestController : ApiController
    {
        ITestBAL testBAL = new TestBAL();

        [HttpGet]
        [Route("Test123")]
        public APIResponse testAPI()
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = testBAL.testAPI();
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
