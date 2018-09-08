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
    public class UserItemController : ApiController
    {
        IUserItemManager _userItemManager = new UserItemManager();

        [Route("useritem/insert")]
        [HttpPost]
        public APIResponse InsertUserItem(UserItem userItem)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = _userItemManager.InsertUserItem(userItem);
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

        [Route("useritem/update")]
        [HttpPost]
        public APIResponse UpdateUserItem(UserItem userItem)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = _userItemManager.UpdateUserItem(userItem);
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

        [Route("useritem/{currentdDte}")]
        [HttpGet]
        public APIResponse GetUserItemByDate(string currentdDte)
        {
            APIResponse response = new APIResponse();
            try
            {

                List<UserItemDtl> userItemDtl = _userItemManager.GetUserItemByDate(currentdDte);
                if (userItemDtl != null)
                {
                    response.Data = userItemDtl;
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

        [Route("useritem/{currentdDte}/custs/{custId}")]
        [HttpGet]
        public APIResponse GetUserItemByDateByCustId(string currentdDte, int custId)
        {
            APIResponse response = new APIResponse();
            try
            {

                List<UserItemDtl> userItemDtl = _userItemManager.GetUserItemByDateByUser(currentdDte,custId);
                if (userItemDtl != null)
                {
                    response.Data = userItemDtl;
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

        [Route("useritem/{currentdDte}/shops/{shopId}")]
        [HttpGet]
        public APIResponse GetUserItemByDateByShopId(string currentdDte, int shopId)
        {
            APIResponse response = new APIResponse();
            try
            {

                List<UserItemDtl> userItemDtl = _userItemManager.GetUserItemByDateByShopId(currentdDte, shopId);
                if (userItemDtl != null)
                {
                    response.Data = userItemDtl;
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
