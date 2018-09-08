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
    public class UserItemRepository : IUserItemRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        IDbConnection _db = new SqlConnection(connectionString);

        public bool InsertUserItem(UserItem userItem)
        {
            try
            {
                string query = string.Format("insert into [UserItem] ([UserId],[ItemId],[Quantity] ,[Scheduled]) values ({0},{1},{2},'{3}')", userItem.UserId, userItem.ItemId, userItem.Quantity, userItem.Scheduled);
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

        public bool UpdateUserItem(UserItem userItem)
        {
            try
            {
                string query = string.Format("update [UserItem] set [UserId]={0},[ItemId]={1},[Quantity]={2} ,[Scheduled]='{3}' where UserItemId={4}", userItem.UserId, userItem.ItemId, userItem.Quantity, userItem.Scheduled,userItem.UserItemId);
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

        public List<UserItemDtl> GetUserItemByDate(string currentDate)
        {
            List<UserItemDtl> userItemDtl = null;
            try
            {
                string dateday = Convert.ToDateTime(currentDate).DayOfWeek.ToString();
                string days=dateday.Substring(0, 3).ToUpper();

                string query = string.Format(@"  select ui.[UserItemId],ui.[UserId],um.Name,ui.[ItemId],im.[Name] as ItemName,ui.[Quantity],ui.[Scheduled],'{1}' as ForDate,'{2}' as DateDay from [UserItem] ui 
                 join [dbo].[ItemMaster] im on im.ItemId=ui.ItemId join [dbo].[UserMaster] um on um.UserId=ui.UserId where ui.Scheduled like '%{0}%' OR ui.Scheduled like '%D%'", days, currentDate,dateday);
                userItemDtl = _db.Query<UserItemDtl>(query).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return userItemDtl;
        }

        public List<UserItemDtl> GetUserItemByDateByUser(string currentDate,int custId)
        {
            List<UserItemDtl> userItemDtl = null;
            try
            {
                string dateday = Convert.ToDateTime(currentDate).DayOfWeek.ToString();
                string days = dateday.Substring(0, 3).ToUpper();

                string query = string.Format(@"  select ui.[UserItemId],ui.[UserId],um.Name,ui.[ItemId],im.[Name] as ItemName,ui.[Quantity],ui.[Scheduled],'{1}' as ForDate,'{2}' as DateDay from [UserItem] ui 
                 join [dbo].[ItemMaster] im on im.ItemId=ui.ItemId join [dbo].[UserMaster] um on um.UserId=ui.UserId where ui.UserId={3} and (ui.Scheduled like '%{0}%' OR ui.Scheduled like '%D%')", days, currentDate, dateday, custId);
                userItemDtl = _db.Query<UserItemDtl>(query).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return userItemDtl;
        }

        public List<UserItemDtl> GetUserItemByDateByShopId(string currentDate, int shopId)
        {
            List<UserItemDtl> userItemDtl = null;
            try
            {
                string dateday = Convert.ToDateTime(currentDate).DayOfWeek.ToString();
                string days = dateday.Substring(0, 3).ToUpper();

                string query = string.Format(@"  select ui.[UserItemId],ui.[UserId],um.Name,ui.[ItemId],im.[Name] as ItemName,ui.[Quantity],ui.[Scheduled],'{1}' as ForDate,'{2}' as DateDay from [UserItem] ui 
                 join [dbo].[ItemMaster] im on im.ItemId=ui.ItemId join [dbo].[UserMaster] um on um.UserId=ui.UserId where um.ShopId={3} and (ui.Scheduled like '%{0}%' OR ui.Scheduled like '%D%')", days, currentDate, dateday, shopId);
                userItemDtl = _db.Query<UserItemDtl>(query).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return userItemDtl;
        }
    }
}
