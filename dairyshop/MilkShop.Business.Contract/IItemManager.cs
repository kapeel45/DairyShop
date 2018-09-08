using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Business.Contract
{
   public interface IItemManager
    {
        int InsertItem(ItemMaster itemMaster);

        List<ItemMaster> ListItemMaster();

        ItemMaster SingleItemMaster(int itemid);

        int UpdateItem(ItemMaster itemMaster);

        int DeleteItem(int itemid);
    }
}
