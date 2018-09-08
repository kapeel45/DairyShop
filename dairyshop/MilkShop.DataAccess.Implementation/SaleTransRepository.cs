using MilkShop.Common;
using MilkShop.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace MilkShop.DataAccess.Implementation
{
    public class SaleTransRepository : ISaleTransRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        IDbConnection _db = new SqlConnection(connectionString);

        public int InsertTransaction(SaleTransection saleTransection)
        {
          
            try
            {
                using (_db)
                {
                    _db.Open();
                    IDbTransaction trans = _db.BeginTransaction();
                    try
                    {
                        if (saleTransection.Sale != null)
                        {
                            int saleIdReturn = _db.Query<int>(@"insert into SaleMaster ([CustId],[UserId],[Amount]) values (@CustId,@UserId,@Amount);SELECT CAST(SCOPE_IDENTITY() as int);", new { saleTransection.Sale.CustId, saleTransection.Sale.UserId, saleTransection.Sale.Amount }, trans).Single();
                            saleTransection.Sale.SaleId = saleIdReturn;              
                        }                                                      

                        if (saleTransection.Sale.SaleId != 0)
                        {
                            foreach (SaleDtlMaster saleDtl in saleTransection.SaleDtl)
                            {
                                saleDtl.SaleId = saleTransection.Sale.SaleId;
                                int returnResult = _db.Execute(@"insert into [SaleDtlMaster] ([ItemId],[Quantity],[Remark],[SaleId]) values (@ItemId,@Quantity,@Remark,@SaleId)", new { saleDtl.ItemId, saleDtl.Quantity, saleDtl.Remark, saleDtl.SaleId }, trans);
                            }

                            saleTransection.TransactionDtl.SaleId = saleTransection.Sale.SaleId;
                            int transactionResult = _db.Execute(@"insert into [Transection] ([CustomUniqueId],[ResponceUniqueId],[UserId],[TransType],[Amount],[Remark],[TransectionId],[SaleId])
                                                                  values (@CustomUniqueId,@ResponceUniqueId,@UserId,@TransType,@Amount,@Remark,@TransectionId,@SaleId)",
                                                               new { saleTransection.TransactionDtl.CustomUniqueId, saleTransection.TransactionDtl.ResponceUniqueId, saleTransection.TransactionDtl.UserId, saleTransection.TransactionDtl.TransType,
                                                               saleTransection.TransactionDtl.Amount,saleTransection.TransactionDtl.Remark,saleTransection.TransactionDtl.TransectionId,saleTransection.TransactionDtl.SaleId}, trans);
                            if (transactionResult != 0)
                            {
                                int activeBalanceResult = _db.Execute(@"update [UserMaster] set [ActiveBalance]=(select [ActiveBalance] from [UserMaster] where UserId=@UserId)+@Amount where UserId=@UserId",
                                                               new
                                                               {
                                                                   UserId=saleTransection.Sale.CustId,
                                                                   Amount=saleTransection.Sale.Amount
                                                               }, trans);
                                trans.Commit();
                            }else
                            {
                                trans.Rollback();
                            }
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                       // return false;
                    }

                    return saleTransection.Sale.SaleId;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<TransactionDtl> GetTransactionByDate(string dayDate)
        {
            List<TransactionDtl> transectioDtl = null;
            try
            {
                string query =string.Format(@"SELECT ts.[TransId],ts.[CustomUniqueId],ts.[ResponceUniqueId],ts.[Date],ts.[UserId],ts.[TransType]
                                              ,ts.[Amount],ts.[Remark],ts.[TransectionId],ts.[SaleId],um.Name FROM [dbo].[Transection] ts
                                            join [dbo].[UserMaster]  um on um.userId=ts.userId
                                            where convert(varchar(10), cast([Date] as date), 110)='{0}'", dayDate);
                transectioDtl = _db.Query<TransactionDtl>(query).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            return transectioDtl;
        }

        public List<TransactionDtl> GetTransactionByDateByCustId(string dayDate,int custId)
        {
            List<TransactionDtl> transectioDtl = null;
            try
            {
                string query = string.Format(@"SELECT ts.[TransId],ts.[CustomUniqueId],ts.[ResponceUniqueId],ts.[Date],ts.[UserId],ts.[TransType]
                                              ,ts.[Amount],ts.[Remark],ts.[TransectionId],ts.[SaleId],um.Name FROM [dbo].[Transection] ts
                                            join [dbo].[UserMaster]  um on um.userId=ts.userId
                                            where ts.UserId={1} and convert(varchar(10), cast([Date] as date), 110)='{0}'", dayDate,custId);
                transectioDtl = _db.Query<TransactionDtl>(query).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            return transectioDtl;
        }

        public List<TransactionDtl> GetTransactionByDateByShopId(string dayDate, int shopId)
        {
            List<TransactionDtl> transectioDtl = null;
            try
            {
                string query = string.Format(@"SELECT ts.[TransId],ts.[CustomUniqueId],ts.[ResponceUniqueId],ts.[Date],ts.[UserId],ts.[TransType]
                                              ,ts.[Amount],ts.[Remark],ts.[TransectionId],ts.[SaleId],um.Name FROM [dbo].[Transection] ts
                                            join [dbo].[UserMaster]  um on um.userId=ts.userId
                                            where  um.ShopId={1} and convert(varchar(10), cast([Date] as date), 110)='{0}'", dayDate, shopId);
                transectioDtl = _db.Query<TransactionDtl>(query).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            return transectioDtl;
        }

    }
}
