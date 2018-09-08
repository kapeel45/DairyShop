using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Common
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public dynamic Data { get; set; }

    }

}
