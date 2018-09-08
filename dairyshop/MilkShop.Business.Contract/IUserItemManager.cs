using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Business.Contract
{
   public interface IUserItemManager
    {

       bool InsertUserItem(UserItem userItem);

       bool UpdateUserItem(UserItem userItem);



       List<UserItemDtl> GetUserItemByDate(string currentdDte);

       List<UserItemDtl> GetUserItemByDateByUser(string currentDate, int custId);

       List<UserItemDtl> GetUserItemByDateByShopId(string currentdDte, int shopId);
    }
}
