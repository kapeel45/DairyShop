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
    public class PriceController : ApiController
    {
        IPriceManager priceManager = new PriceManager();

        [Route("prices/insert")]
        [HttpPost]
        public APIResponse InsertItem(PriceMaster priceMaster)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = priceManager.InsertPrice(priceMaster);
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

        [Route("prices")]
        [HttpGet]
        public APIResponse GetAllPrice()
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = priceManager.ListPriceMaster();
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

        [Route("prices/{priceid}")]
        [HttpGet]
        public APIResponse GetSinglePrice(int priceid)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = priceManager.SinglePriceMaster(priceid);
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

        [Route("prices/update")]
        [HttpPost]
        public APIResponse UpdatePrice(PriceMaster priceMaster)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = priceManager.UpdatePrice(priceMaster);
                if (response.Data != 0)
                {
                    response.Success = true;
                    response.Error = null;
                }
                else
                {
                    response.Success = false;
                    response.Error = "Record not Updated";
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


        [Route("prices/delete/{priceid}")]
        [HttpGet]
        public APIResponse DeletePrice(int priceid)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = priceManager.DeletePrice(priceid);
                if (response.Data != 0)
                {
                    response.Success = true;
                    response.Error = null;
                }
                else
                {
                    response.Success = false;
                    response.Error = "Record not Deleted";
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
