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
    public class SaleTransectionController : ApiController
    {
        ISaleTransManager saleTransManager = new SaleTransManager();

        [Route("sale/transaction")]
        [HttpPost]
        public bool SaleTransection()
        {   //SaleTransection saleTransection
            bool result = false;
            try
            {
                SaleTransection saleTransection = new Common.SaleTransection();
                saleTransection.SaleDtl = new List<SaleDtlMaster>();
                saleTransection.TransactionDtl = new Transaction();
                saleTransection.Sale = new SaleMaster();

                SaleMaster saleMaster = new SaleMaster();
                saleMaster.Amount = 2000;
                saleMaster.CustId = 1;
                saleMaster.Date = DateTime.Now;
                saleMaster.IsDelete = false;
                saleMaster.UserId = 1;
                saleTransection.Sale = saleMaster;

                // List<SaleMaster> saleList = new List<SaleMaster>(); 
                SaleDtlMaster objSale = new SaleDtlMaster() { ItemId = 1, Quantity = 2, SaleId = 0, Remark = "" };
                saleTransection.SaleDtl.Add(objSale);
                saleTransection.SaleDtl.Add(objSale);

                Transaction transaction = new Transaction();
                transaction.Amount = 1000;
                transaction.CustomUniqueId = Convert.ToString(Guid.NewGuid());
                transaction.UserId = 1;
                transaction.TransType = "Cr";
                saleTransection.TransactionDtl = transaction;


                int returRresult = saleTransManager.InsertTransaction(saleTransection);
                if (returRresult != 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        [Route("transactions/{dayDate}")]
        [HttpGet]
        public APIResponse GetTransaction(string dayDate)
        {

            APIResponse response = new APIResponse();
            try
            {

                List<TransactionDtl> transactionDtl = saleTransManager.GetTransactionByDate(dayDate);
                if (transactionDtl != null)
                {
                    response.Data = transactionDtl;
                    response.Success = true;
                    response.Error = null;
                }
                else
                {
                    response.Success = false;
                    response.Error = "Record not found";
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

        [Route("transactions/{dayDate}/custId/{custId}")]
        [HttpGet]
        public APIResponse GetTransactionByDateByCustId(string dayDate, int custId)
        {
            APIResponse response = new APIResponse();
            try
            {
                List<TransactionDtl> transactionDtl = saleTransManager.GetTransactionByDateByCustId(dayDate,custId);
                if (transactionDtl != null)
                {
                    response.Data = transactionDtl;
                    response.Success = true;
                    response.Error = null;
                }
                else
                {
                    response.Success = false;
                    response.Error = "Record not found";
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

        [Route("transactions/{dayDate}/shopId/{shopId}")]
        [HttpGet]
        public APIResponse GetTransactionByDateByShopId(string dayDate, int shopId)
        {
            APIResponse response = new APIResponse();
            try
            {
                List<TransactionDtl> transactionDtl = saleTransManager.GetTransactionByDateByShopId(dayDate,shopId);
                if (transactionDtl != null)
                {
                    response.Data = transactionDtl;
                    response.Success = true;
                    response.Error = null;
                }
                else
                {
                    response.Success = false;
                    response.Error = "Record not found";
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
