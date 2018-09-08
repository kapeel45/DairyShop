using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Common
{
  public  class DbEntityDetail
    {

    }
    public class UserMasterDetail
    {
        public int UserId { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string MobileNo { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public int RoleId { set; get; }
        public int ShopId { set; get; }

        public string RoleName { set; get; }
        public string ShopName { set; get; }

        public decimal ActiveBalance { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }

    public class UserItemDtl
    {
        public int UserItemId { set; get; }
        public int UserId { set; get; }
        public string Name { get; set; }
        public int ItemId { set; get; }
        public string ItemName { set; get; }
        public int Quantity { set; get; }
        public string Scheduled { set; get; }
        public string ForDate { get; set; }
        public string DateDay { get; set; }
    }

    public class TransactionDtl
    {
        public int TransId { set; get; }
        public string CustomUniqueId { set; get; }
        public int ResponceUniqueId { set; get; }
        public DateTime Date { set; get; }
        public int UserId { set; get; }
        public string Name { set; get; }
        public string TransType { set; get; }
        public decimal Amount { set; get; }
        public string Remark { set; get; }
        public string TransectionId { set; get; }
        public int SaleId { set; get; }
    }
}
