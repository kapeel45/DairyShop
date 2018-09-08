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
    public class UnitManager : IUnitManager
    {
        IUnitRepository unitRepository = new UnitRepository();

        public int InsertUnit(UnitMaster unitMaster)
        {
            return unitRepository.InsertUnit(unitMaster);
        }

        public List<UnitMaster> ListUnitMaster()
        {
            return unitRepository.ListUnitMaster();
        }

        public UnitMaster SingleUnitMaster(int unitid)
        {
            return unitRepository.SingleUnitMaster(unitid);
        }

        public int UpdateUnit(UnitMaster unitMaster)
        {
            return unitRepository.UpdateUnit(unitMaster);
        }

        public int DeleteUnit(int unitid)
        {
            return unitRepository.DeleteUnit(unitid);
        }
    }
}
