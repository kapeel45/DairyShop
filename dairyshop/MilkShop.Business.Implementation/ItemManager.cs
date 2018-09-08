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
    public class ItemManager : IItemManager
    {
        IItemRepository itemRepository = new ItemRepository();

        public int InsertItem(ItemMaster itemMaster)
        {
            return itemRepository.InsertItem(itemMaster);
        }

        public List<ItemMaster> ListItemMaster()
        {
            return itemRepository.ListItemMaster();
        }

        public ItemMaster SingleItemMaster(int unitid)
        {
            return itemRepository.SingleItemMaster(unitid);
        }

        public int UpdateItem(ItemMaster itemMaster)
        {
            return itemRepository.UpdateItem(itemMaster);
        }
        public int DeleteItem(int itemid)
        {
            return itemRepository.DeleteItem(itemid);
        }
    }
}
