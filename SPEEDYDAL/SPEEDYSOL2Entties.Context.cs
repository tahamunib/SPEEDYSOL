﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPEEDYDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SPEEDYSOLEntities : DbContext
    {
        public SPEEDYSOLEntities()
            : base("name=SPEEDYSOLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountCategory> AccountCategory { get; set; }
        public virtual DbSet<AccountGroup> AccountGroup { get; set; }
        public virtual DbSet<DailySales> DailySales { get; set; }
        public virtual DbSet<GodownItems> GodownItems { get; set; }
        public virtual DbSet<Godowns> Godowns { get; set; }
        public virtual DbSet<ItemBrand> ItemBrand { get; set; }
        public virtual DbSet<ItemGroup> ItemGroup { get; set; }
        public virtual DbSet<ItemManufacturer> ItemManufacturer { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<OrderBooker> OrderBooker { get; set; }
        public virtual DbSet<PurchaseDamageChallan> PurchaseDamageChallan { get; set; }
        public virtual DbSet<PurchaseDamageChallanItems> PurchaseDamageChallanItems { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<PurchaseRecievingChallan> PurchaseRecievingChallan { get; set; }
        public virtual DbSet<PurchaseRecievingChallanItems> PurchaseRecievingChallanItems { get; set; }
        public virtual DbSet<PurchaseReturnChallan> PurchaseReturnChallan { get; set; }
        public virtual DbSet<PurchaseReturnChallanItems> PurchaseReturnChallanItems { get; set; }
        public virtual DbSet<SaleOrder> SaleOrder { get; set; }
        public virtual DbSet<SaleOrderDetail> SaleOrderDetail { get; set; }
        public virtual DbSet<SalesDamageChallan> SalesDamageChallan { get; set; }
        public virtual DbSet<SalesDamageChallanItems> SalesDamageChallanItems { get; set; }
        public virtual DbSet<SalesDeliveryChallan> SalesDeliveryChallan { get; set; }
        public virtual DbSet<SalesDeliveryChallanItems> SalesDeliveryChallanItems { get; set; }
        public virtual DbSet<Salesman> Salesman { get; set; }
        public virtual DbSet<SalesReturnChallan> SalesReturnChallan { get; set; }
        public virtual DbSet<SalesReturnChallanItems> SalesReturnChallanItems { get; set; }
        public virtual DbSet<SSAccounts> SSAccounts { get; set; }
        public virtual DbSet<SSClients> SSClients { get; set; }
        public virtual DbSet<SSUsers> SSUsers { get; set; }
        public virtual DbSet<SSUsersRoles> SSUsersRoles { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Vouchers> Vouchers { get; set; }
        public virtual DbSet<SSEnumValues> SSEnumValues { get; set; }
        public virtual DbSet<SSEnum> SSEnum { get; set; }
        public virtual DbSet<CashSlip> CashSlip { get; set; }
        public virtual DbSet<ChequeSlip> ChequeSlip { get; set; }
        public virtual DbSet<CreditSlip> CreditSlip { get; set; }
        public virtual DbSet<RecoverySlip> RecoverySlip { get; set; }
    
        public virtual ObjectResult<uspGetUser_Result> uspGetUser(string loginid)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetUser_Result>("uspGetUser", loginidParameter);
        }
    }
}
