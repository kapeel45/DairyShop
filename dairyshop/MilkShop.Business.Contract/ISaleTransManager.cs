using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Business.Contract
{
  public  interface ISaleTransManager
    {
      int InsertTransaction(SaleTransection saleTransection);

      List<TransactionDtl> GetTransactionByDate(string dayDate);

      List<TransactionDtl> GetTransactionByDateByCustId(string dayDate, int custId);

      List<TransactionDtl> GetTransactionByDateByShopId(string dayDate, int shopId);
    }
}
