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
    public class SaleTransManager : ISaleTransManager
    {
        ISaleTransRepository saleTransRepository = new SaleTransRepository();

       public int InsertTransaction(SaleTransection saleTransection)
        {
            return saleTransRepository.InsertTransaction(saleTransection);
        }
       public List<TransactionDtl> GetTransactionByDate(string dayDate)
       {
           return saleTransRepository.GetTransactionByDate(dayDate);
       }

       public List<TransactionDtl> GetTransactionByDateByCustId(string dayDate, int custId)
       {
           return saleTransRepository.GetTransactionByDateByCustId(dayDate,custId);
       }

       public List<TransactionDtl> GetTransactionByDateByShopId(string dayDate, int shopId)
       {
           return saleTransRepository.GetTransactionByDateByShopId(dayDate,shopId);
       }
    }
}
