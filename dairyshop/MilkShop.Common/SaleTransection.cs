using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Common
{
    public class SaleTransection
    {
        public SaleMaster Sale { get; set; }
        public List<SaleDtlMaster> SaleDtl { get; set; }
        public Transaction TransactionDtl { get; set; }
    }
}
