using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.DataAccess.Contract
{
   public interface IUserItemRepository
    {
        bool InsertUserItem(UserItem userItem);

        bool UpdateUserItem(UserItem userItem);

        List<UserItemDtl> GetUserItemByDate(string currentdDte);

        List<UserItemDtl> GetUserItemByDateByUser(string currentDate, int custId);

        List<UserItemDtl> GetUserItemByDateByShopId(string currentDate, int shopId);
    }
}
