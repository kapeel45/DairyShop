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
    public class ItemRepository : IItemRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        IDbConnection _db = new SqlConnection(connectionString);

        public int InsertItem(ItemMaster itemMaster)
        {
            int result = 0;
            try
            {
                string query = string.Format("insert into ItemMaster (Name,Discription,UnitId) values ('{0}','{1}',{2})", itemMaster.Name, itemMaster.Discription, itemMaster.UnitId);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw EX;
            }
            return result;
        }

        public List<ItemMaster> ListItemMaster()
        {
            List<ItemMaster> lstItemMaster = new List<ItemMaster>();

            try
            {
                string query = "select * from ItemMaster";
                lstItemMaster = _db.Query<ItemMaster>(query).ToList();
                //  lstUnitMaster = temp;
            }
            catch (Exception)
            {

                throw;
            }
            return lstItemMaster;
        }

        public ItemMaster SingleItemMaster(int itemid)
        {
            ItemMaster itemMaster = new ItemMaster();

            try
            {
                string query = string.Format("select * from ItemMaster where ItemId={0}", itemid);
                itemMaster = _db.Query<ItemMaster>(query).FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
            return itemMaster;
        }

        public int UpdateItem(ItemMaster itemMaster)
        {
            int result = 0;
            try
            {
                string query = string.Format("update ItemMaster set Name='{0}',Discription='{1}',UnitId={2} where ItemId={3}", itemMaster.Name, itemMaster.Discription, itemMaster.UnitId, itemMaster.ItemId);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw;
            }
            return result;
        }

        public int DeleteItem(int itemid)
        {
            int result = 0;
            try
            {
                string query = string.Format("update ItemMaster set IsDelete={1} where ItemId={0}",1, itemid);
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
