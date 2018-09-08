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
using MilkShop.Common;

namespace MilkShop.DataAccess.Implementation
{
    public class OrderOrCancelRepository : IOrderOrCancelRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        IDbConnection _db = new SqlConnection(connectionString);

        public bool InsertOrderCancel(OrderCancelMaster orderCancel)
        {
            try
            {
                string query = string.Format(@"insert into [OrderCancelMaster] ([UserId],[ItemId],[Quantity] ,[TransType],[Status]) values ({0},{1},{2},'{3}',{4})"
                                        , orderCancel.UserId, orderCancel.ItemId, orderCancel.Quantity, orderCancel.TransType, orderCancel.Status);
                int intResult = _db.Execute(query);
                if (intResult != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool UpdateOrderCancel(OrderCancelMaster orderCancel)
        {
            try
            {
                string query = string.Format(@"update [OrderCancelMaster] set [UserId]={0},[ItemId]={1},[Quantity]={2} ,[TransType]={3},[Status]={4} where OrderCancelId={5}"
                                        , orderCancel.UserId, orderCancel.ItemId, orderCancel.Quantity, orderCancel.TransType, orderCancel.Status,orderCancel.OrderCancelId);
                int intResult = _db.Execute(query);
                if (intResult != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

    }
}
