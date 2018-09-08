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
    public class UserItemManager : IUserItemManager
    {
        IUserItemRepository _userItemRepository = new UserItemRepository();

        public bool InsertUserItem(UserItem userItem)
        {
            return _userItemRepository.InsertUserItem(userItem);
        }

  
        public bool UpdateUserItem(UserItem userItem)
        {
            return _userItemRepository.UpdateUserItem(userItem);
        }

        public List<UserItemDtl> GetUserItemByDate(string currentdDte)
        {
            return _userItemRepository.GetUserItemByDate(currentdDte);
        }

        public List<UserItemDtl> GetUserItemByDateByUser(string currentDate, int custId)
        {
            return _userItemRepository.GetUserItemByDateByUser(currentDate,custId);
        }

        public List<UserItemDtl> GetUserItemByDateByShopId(string currentDate, int shopId)
        {
            return _userItemRepository.GetUserItemByDateByShopId(currentDate, shopId);
        }
    }
}
