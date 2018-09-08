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
    public class OrderOrCancelController : ApiController
    {
        IOrderOrCancelManager _userItemManager = new OrderOrCancelManager();

        [Route("ordercancel/insert")]
        [HttpPost]
        public APIResponse InsertOrderOrCancel(OrderCancelMaster orderCancel)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = _userItemManager.InsertOrderCancel(orderCancel);
                if (response.Data != 0)
                {
                    response.Success = true;
                    response.Error = null;
                }
                else
                {
                    response.Success = false;
                    response.Error = "Record not inserted";
                }
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
