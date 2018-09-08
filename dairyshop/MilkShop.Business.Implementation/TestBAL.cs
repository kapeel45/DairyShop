using MilkShop.Business.Contract;
using MilkShop.DataAccess.Contract;
using MilkShop.DataAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Business.Implementation
{
    public class TestBAL : ITestBAL
    {
        ITestDAL testDAL = new TestAPIDAL();
        public List<string> testAPI()
        {
            return testDAL.TestAPI();
        }
    }
}
