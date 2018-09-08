using MilkShop.Business.Contract;
using MilkShop.Common;
using MilkShop.DataAccess.Contract;
using MilkShop.DataAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Business.Implementation
{
   public class UserManager : IUserManager
    {
       IUserRepository userRepository = new UserRepository();
       public int InsertUser(UserMaster userMaster)
       {
           return userRepository.InsertUser(userMaster);
       }
       public int UpdateUserMaster(UserMasterDetail userMasterDetail)
       {
           return userRepository.UpdateUserMaster(userMasterDetail);
       }
       public int DeleteUserMaster(int userId)
       {
           return userRepository.DeleteUserMaster(userId);
       }
      public List<UserMasterDetail> ListUserMaster()
       {
           return userRepository.ListUserMaster();
       }

     public  UserMasterDetail SingleUserMaster(int userid)
       {
           return userRepository.SingleUserMaster(userid);

       }

     public UserMasterDetail GetValidUser(string username, string password)
     {
         return userRepository.GetValidUser(username, password);
     }
    }
}
