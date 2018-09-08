using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Business.Contract
{
   public interface IUserManager
    {
        int InsertUser(UserMaster priceMaster);

        List<UserMasterDetail> ListUserMaster();

        UserMasterDetail SingleUserMaster(int userid);

        int UpdateUserMaster(UserMasterDetail userMaster);

        int DeleteUserMaster(int userid);

        UserMasterDetail GetValidUser(string username, string password);
    }
}
