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
    public class StatusManager : IStatusManager
    {
        IStatusRepository statusRepository = new StatusRepository();


        public List<StatusMaster> GetAllStatus()
        {
         return   statusRepository.GetAllStatus();
        }
    }
}
