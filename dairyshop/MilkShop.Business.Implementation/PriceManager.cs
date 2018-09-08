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
   public class PriceManager : IPriceManager
    {
       IPriceRepository priceRepository = new PriceRepository();

      public int InsertPrice(PriceMaster priceMaster)
       {
           return priceRepository.InsertPrice(priceMaster);
       }

     public  List<PriceMaster> ListPriceMaster()
       {
           return priceRepository.ListPriceMaster();

       }

     public  PriceMaster SinglePriceMaster(int priceid)
       {
           return priceRepository.SinglePriceMaster(priceid);

       }

     public  int UpdatePrice(PriceMaster priceMaster)
       {
           return priceRepository.UpdatePrice(priceMaster);

       }
     public int DeletePrice(int priceid)
     {
         return priceRepository.DeletePrice(priceid);
     }
    }
}
