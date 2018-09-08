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
    public class UnitRepository : IUnitRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        IDbConnection _db = new SqlConnection(connectionString);
       
        public int InsertUnit(UnitMaster unitMaster)
        {
            int result=0;
            try
            {
                string query =string.Format("insert into UnitMaster (UnitName) values ('{0}')",unitMaster.UnitName);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {
                
                throw;
            }
            return result;
        }

        public List<UnitMaster> ListUnitMaster()
        {
            List<UnitMaster> lstUnitMaster = new List<UnitMaster>();

            try
            {
                string query = "select * from UnitMaster";
                lstUnitMaster = _db.Query<UnitMaster>(query).ToList();
              //  lstUnitMaster = temp;
            }
            catch (Exception)
            {
                
                throw;
            }
            return lstUnitMaster;
        }

        public UnitMaster SingleUnitMaster(int unitid)
        {
            UnitMaster unitMaster = new UnitMaster();

            try
            {
                string query = string.Format("select * from UnitMaster where UnitId={0}", unitid);
                unitMaster = _db.Query<UnitMaster>(query).FirstOrDefault();
               
            }
            catch (Exception)
            {

                throw;
            }
            return unitMaster;
        }

        public int UpdateUnit(UnitMaster unitMaster)
        {
            int result = 0;
            try
            {
                string query = string.Format("update UnitMaster set UnitName='{0}' where UnitId={1}", unitMaster.UnitName,unitMaster.UnitId);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw;
            }
            return result;
        }
        public int DeleteUnit(int unitid)
        {
            int result = 0;
            try
            {
                string query = string.Format("update  UnitMaster set IsDeleted={0} where UnitId={1}",1, unitid);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw;
            }
            return result;
        }
    }
}
