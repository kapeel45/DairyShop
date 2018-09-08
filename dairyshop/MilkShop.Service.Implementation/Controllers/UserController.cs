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
    
    public class UserController : ApiController
    { 
        IUserManager userManager = new UserManager();
        [Route("users/insert")]
        [HttpPost]
        public APIResponse InsertUnit(UserMaster userMaster)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = userManager.InsertUser(userMaster);
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


        [Route("users")]
        [HttpGet]
        public APIResponse GetAllUser()
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = userManager.ListUserMaster();
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

        [Route("users/{userid}")]
        [HttpGet]
        public APIResponse GetSingleUser(int userId)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = userManager.SingleUserMaster(userId);
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

        [Route("users/{username}/{password}")]
        [HttpGet]
        public APIResponse GetValidUser(string username, string password)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = userManager.GetValidUser(username, password);
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

        [Route("users/update")]
        [HttpPost]
        public APIResponse UpdateUser(UserMasterDetail userMasterDetail)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = userManager.UpdateUserMaster(userMasterDetail);
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

        [Route("users/delete/{userid}")]
        [HttpGet]
        public APIResponse DeleteUsers(int userid)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = userManager.DeleteUserMaster(userid);
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
