using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Business.Contract
{
   public interface IPriceManager
    {
        int InsertPrice(PriceMaster priceMaster);

        List<PriceMaster> ListPriceMaster();

        PriceMaster SinglePriceMaster(int priceid);

        int UpdatePrice(PriceMaster priceMaster);

        int DeletePrice(int priceid);
        
    }
}
