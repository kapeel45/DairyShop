using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShop.Common
{
    public class ItemMaster
    {
        public int ItemId { set; get; }
        public string Name { set; get; }
        public string Discription { set; get; }
        public int UnitId { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }
    public class UnitMaster
    {
        public int UnitId { set; get; }
        public string UnitName { set; get; }
    }
    public class OrderCancelMaster
    {
        public int OrderCancelId { set; get; }
        public int UserId { set; get; }
        public int ItemId { set; get; }
        public int Quantity { set; get; }
        public string TransType { set; get; }
        public int Status { set; get; }
    }
    public class Permission
    {
        public int PermissionId { set; get; }
        public string Name { set; get; }
    }
    public class PermissionType
    {
        public int TypeId { set; get; }
        public string TypeName { set; get; }
    }
    public class PriceMaster
    {
        public int PriceId { set; get; }
        public int ItemId { set; get; }
        public decimal Price { set; get; }
        public DateTime Date { set; get; }
        public bool IsDelete { set; get; }
    }
    public class RoleMaster
    {
        public int RoleId { set; get; }
        public string RoleName { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }
    public class RoleRuleRelation
    {
        public int RoleRuleId { set; get; }
        public int RoleId { set; get; }
        public int RuleId { set; get; }
        public bool IsDelete { set; get; }
    }
    public class RuleMaster
    {
        public int RuleId { set; get; }
        public int TypeId { set; get; }
        public int PermissionId { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }
    public class SaleDtlMaster
    {
        public int SaleDtlID { set; get; }
        public int ItemId { set; get; }
        public int Quantity { set; get; }
        public string Remark { set; get; }
        public int SaleId { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }
    public class SaleMaster
    {
        public int SaleId { set; get; }
        public DateTime Date { set; get; }
        public int CustId { set; get; }
        public int UserId { set; get; }
        public decimal Amount { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }
    public class ShopMaster
    {
        public int ShopId { set; get; }
        public string ShopName { set; get; }
        public string Address { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }
    public class StatusMaster
    {
        public int StatusMasterId { set; get; }
        public int Name { set; get; }
    }
    public class Transaction
    {

        public int TransId { set; get; }
        public string CustomUniqueId { set; get; }
        public int ResponceUniqueId { set; get; }
        public DateTime Date { set; get; }
        public int UserId { set; get; }
        public string TransType { set; get; }
        public decimal Amount { set; get; }
        public string Remark { set; get; }
        public string TransectionId { set; get; }
        public int SaleId { set; get; }
    }
    public class UserItem
    {
        public int UserItemId { set; get; }
        public int UserId { set; get; }
        public int ItemId { set; get; }
        public int Quantity { set; get; }
        public string Scheduled { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }
    public class UserMaster
    {
        public int UserId { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string MobileNo { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public int RoleId { set; get; }
        public int ShopId { set; get; }
        public decimal ActiveBalance { set; get; }
        public bool IsDelete { set; get; }
        public DateTime DOC { set; get; }
    }
}
