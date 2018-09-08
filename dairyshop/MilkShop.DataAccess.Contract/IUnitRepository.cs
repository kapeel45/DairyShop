using MilkShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.DataAccess.Contract
{
  public  interface IUnitRepository
    {
      int InsertUnit(UnitMaster unitMaster);

      List<UnitMaster> ListUnitMaster();

      UnitMaster SingleUnitMaster(int unitid);

      int UpdateUnit(UnitMaster unitMaster);

      int DeleteUnit(int unitid);
    }
}
