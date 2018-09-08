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

    public class UnitController : ApiController
    {
       
        IUnitManager unitManager=new UnitManager();

        [Route("units/insert")]
        [HttpPost]
        public APIResponse InsertUnit(UnitMaster unitMaster)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = unitManager.InsertUnit(unitMaster);
                if (response.Data != 0)
                {
                    response.Success = true;
                    response.Error = null;
                }else
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

        [Route("units")]
        [HttpGet]
        public APIResponse GetAllUnit()
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = unitManager.ListUnitMaster();
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

        [Route("units/{unitid}")]
        [HttpGet]
        public APIResponse GetSingleUnit(int unitid)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = unitManager.SingleUnitMaster(unitid);
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

        [Route("units/update")]
        [HttpPost]
        public APIResponse UpdateUnit(UnitMaster unitMaster)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = unitManager.UpdateUnit(unitMaster);
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

        [Route("units/delete/{unitid}")]
        [HttpGet]
        public APIResponse DeleteUnit(int unitid)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.Data = unitManager.DeleteUnit(unitid);
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
