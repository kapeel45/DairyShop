using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MilkShop.DataAccess.Contract;
namespace MilkShop.DataAccess.Implementation
{
   public class UserRepository : IUserRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        IDbConnection _db = new SqlConnection(connectionString);

        public int InsertUser(UserMaster userMaster)
        {
            int result = 0;
            try
            {
                string query = string.Format("insert into UserMaster(Name,Address,MobileNo,UserName,Password,RoleId,ShopId) values ('{0}','{1}','{2}','{3}','{4}',{5},{6})", userMaster.Name, userMaster.Address, userMaster.MobileNo, userMaster.UserName, userMaster.Password, userMaster.RoleId, userMaster.ShopId);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw EX;
            }
            return result;
        }
        public List<UserMasterDetail> ListUserMaster()
        {
            List<UserMasterDetail> lstDbEntityDetail = new List<UserMasterDetail>();

            try
            {
                string query = @"select RoleMaster.RoleId,ShopMaster.ShopId, RoleMaster.RoleName,ShopMaster.ShopName, UserMaster.Name,UserMaster.Address,UserMaster.MobileNo,UserMaster.UserName,UserMaster.Password from UserMaster
                                inner join RoleMaster on RoleMaster.RoleId=UserMaster.RoleId 
                                inner join ShopMaster on ShopMaster.ShopId=UserMaster.ShopId where UserMaster.IsDelete=0 and ShopMaster.IsDelete=0 and RoleMaster.IsDelete=0";
                lstDbEntityDetail = _db.Query<UserMasterDetail>(query).ToList();
                //  lstUnitMaster = temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lstDbEntityDetail;
        }
        public UserMasterDetail SingleUserMaster(int userId)
        {
            UserMasterDetail dbEntityDetail = new UserMasterDetail();

            try
            {
                string query = string.Format(@"select RoleMaster.RoleId,ShopMaster.ShopId, RoleMaster.RoleName,ShopMaster.ShopName, UserMaster.Name,UserMaster.Address,UserMaster.MobileNo,UserMaster.UserName,UserMaster.Password from UserMaster
                                inner join RoleMaster on RoleMaster.RoleId=UserMaster.RoleId 
                                inner join ShopMaster on ShopMaster.ShopId=UserMaster.ShopId where UserMaster.IsDelete=0 and ShopMaster.IsDelete=0 and RoleMaster.IsDelete=0 and UserMaster.UserId={0}", userId);
                dbEntityDetail = _db.Query<UserMasterDetail>(query).FirstOrDefault();
                //  lstUnitMaster = temp;
            }
            catch (Exception)
            {

                throw;
            }
            return dbEntityDetail;
        }
        public int DeleteUserMaster(int userId)
        {
            int result = 0;
            try
            {
                string query = string.Format("update UserMaster set IsDelete={1} where UserId={0}", 1, userId);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw;
            }
            return result;
        }
        public int UpdateUserMaster(UserMasterDetail userMaster)
        {
            int result = 0;
            try
            {
                string query = string.Format("update UserMaster set Name='{0}',Address='{1}',MobileNo='{2}',UserName='{3}',Password='{4}',RoleId={5},ShopId={6} where UserId={7}", userMaster.Name, userMaster.Address, userMaster.MobileNo, userMaster.UserName, userMaster.Password, userMaster.RoleId, userMaster.ShopId, userMaster.UserId);
                result = _db.Execute(query);
            }
            catch (Exception EX)
            {

                throw;
            }
            return result;
        }

        public UserMasterDetail GetValidUser(string userName,string password)
        {
            UserMasterDetail dbEntityDetail = new UserMasterDetail();

            try
            {
                string query = string.Format(@"select RoleMaster.RoleId,ShopMaster.ShopId, RoleMaster.RoleName,ShopMaster.ShopName, UserMaster.Name,UserMaster.Address,UserMaster.MobileNo,UserMaster.UserName,UserMaster.Password from UserMaster
                                inner join RoleMaster on RoleMaster.RoleId=UserMaster.RoleId 
                                inner join ShopMaster on ShopMaster.ShopId=UserMaster.ShopId where UserMaster.IsDelete=0 and ShopMaster.IsDelete=0 and RoleMaster.IsDelete=0 and UserMaster.Username='{0}' and UserMaster.Password='{1}'", userName,password);
                dbEntityDetail = _db.Query<UserMasterDetail>(query).FirstOrDefault();
                //  lstUnitMaster = temp;
            }
            catch (Exception ex)
            {

                throw;
            }
            return dbEntityDetail;
        }
        
    }
}
