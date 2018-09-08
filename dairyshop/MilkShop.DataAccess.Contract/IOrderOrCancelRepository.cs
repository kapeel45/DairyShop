using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.DataAccess.Contract
{
   public interface IOrderOrCancelRepository
    {
       bool InsertOrderCancel(Common.OrderCancelMaster orderCancel);
    }
}
