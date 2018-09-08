using MilkShop.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.DataAccess.Implementation
{
    public class TestAPIDAL : ITestDAL
    {
        public List<string> TestAPI()
        {
            List<string> obj = new List<string>();
            obj.Add("Abcd");
            obj.Add("xyz");
            obj.Add("qwer");
            return obj;
        }
    }
}
