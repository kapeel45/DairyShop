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
    public class OrderOrCancelManager : IOrderOrCancelManager
    {
        IOrderOrCancelRepository _userItemRepository = new OrderOrCancelRepository();
        public bool InsertOrderCancel(OrderCancelMaster orderCancel)
        {
            return _userItemRepository.InsertOrderCancel(orderCancel);
        }
    }
}
