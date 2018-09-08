using MilkShop.Common;
using MilkShop.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
namespace MilkShop.DataAccess.Implementation
{
    public class PriceRepository : IPriceRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        IDbConnection _db = new SqlConnection(connectionString);

        public int InsertPrice(PriceMaster priceMaster)
        {
          
            int result = 0;
            try
            {
                string query = string.Format("insert into PriceMaster (ItemId,Price,Date) values({0},{1})", priceMaster.ItemId, priceMaster.Price);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw EX;
            }
            return result;
        }

        public List<PriceMaster> ListPriceMaster()
        {
            List<PriceMaster> lstPriceMaster = new List<PriceMaster>();

            try
            {
                string query = "select * from PriceMaster";
                lstPriceMaster = _db.Query<PriceMaster>(query).ToList();
                //  lstUnitMaster = temp;
            }
            catch (Exception)
            {

                throw;
            }
            return lstPriceMaster;
        }

        public PriceMaster SinglePriceMaster(int priceid)
        {
            PriceMaster priceMaster = new PriceMaster();

            try
            {
                string query = string.Format("select * from PriceMaster where PriceId={0}", priceid);
                priceMaster = _db.Query<PriceMaster>(query).FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
            return priceMaster;
        }

        public int UpdatePrice(PriceMaster priceMaster)
        {
            int result = 0;
            try
            {
                string query = string.Format("update PriceMaster set ItemId={0},Price={1} where PriceId={2}", priceMaster.ItemId, priceMaster.Price, priceMaster.PriceId);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw EX;
            }
            return result;
        }

        public int DeletePrice(int priceid)
        {
            int result = 0;
            try
            {
                string query = string.Format("update PriceMaster set IsDelete={0} where PriceId={1}", 1,priceid);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw EX;
            }
            return result;
        }
    }
}
