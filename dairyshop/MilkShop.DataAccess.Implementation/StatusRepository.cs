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
  public  class StatusRepository : IStatusRepository
    {
           static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        IDbConnection _db = new SqlConnection(connectionString);
       
        public List<StatusMaster> GetAllStatus()
        {
            List<StatusMaster> lstStatus = new List<StatusMaster>();

            try
            {
                string query = @"select StatusMasterId,Name from StatusMaster";
                lstStatus = _db.Query<StatusMaster>(query).ToList();
                //  lstUnitMaster = temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lstStatus;
        }

       
    }
}
