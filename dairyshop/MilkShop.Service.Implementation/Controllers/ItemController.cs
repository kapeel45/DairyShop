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
    //[RoutePrefix("item")]
    public class ItemController : ApiController
    {
        IItemManager itemManager = new ItemManager();
        
        [Route("items/insert")]
        [HttpPost]
        public APIResponse InsertItem(ItemMaster itemMaster)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = itemManager.InsertItem(itemMaster);
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

        [Route("items")]
        [HttpGet]
        public APIResponse GetAllitem()
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = itemManager.ListItemMaster();
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

        [Route("items/{itemid}")]
        [HttpGet]
        public APIResponse GetSingleitem(int itemid)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = itemManager.SingleItemMaster(itemid);
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

        [Route("items/update")]
        [HttpPost]
        public APIResponse Updateitem(ItemMaster itemMaster)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = itemManager.UpdateItem(itemMaster);
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

        [Route("items/delete/{itemid}")]
        [HttpGet]
        public APIResponse Deleteitem(int itemid)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = itemManager.DeleteItem(itemid);
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
