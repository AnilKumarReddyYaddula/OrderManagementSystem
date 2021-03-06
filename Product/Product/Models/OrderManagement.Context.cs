﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Product.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OrderManagementSystemEntities : DbContext
    {
        public OrderManagementSystemEntities()
            : base("name=OrderManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int SP_CreateOrder(Nullable<int> status, Nullable<int> userId, string shippingAddress, Nullable<int> productId, Nullable<int> quantity, Nullable<int> orderId)
        {
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var shippingAddressParameter = shippingAddress != null ?
                new ObjectParameter("shippingAddress", shippingAddress) :
                new ObjectParameter("shippingAddress", typeof(string));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("productId", productId) :
                new ObjectParameter("productId", typeof(int));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("quantity", quantity) :
                new ObjectParameter("quantity", typeof(int));
    
            var orderIdParameter = orderId.HasValue ?
                new ObjectParameter("orderId", orderId) :
                new ObjectParameter("orderId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CreateOrder", statusParameter, userIdParameter, shippingAddressParameter, productIdParameter, quantityParameter, orderIdParameter);
        }
    
        public virtual int SP_DeleteOrder(Nullable<int> orderId)
        {
            var orderIdParameter = orderId.HasValue ?
                new ObjectParameter("OrderId", orderId) :
                new ObjectParameter("OrderId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_DeleteOrder", orderIdParameter);
        }
    
        public virtual ObjectResult<SP_OrderByAdministrator_Result> SP_OrderByAdministrator()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_OrderByAdministrator_Result>("SP_OrderByAdministrator");
        }
    
        public virtual ObjectResult<SP_OrderByAdministratorInDetail_Result> SP_OrderByAdministratorInDetail()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_OrderByAdministratorInDetail_Result>("SP_OrderByAdministratorInDetail");
        }
    
        public virtual ObjectResult<SP_OrderByBuyer_Result> SP_OrderByBuyer(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_OrderByBuyer_Result>("SP_OrderByBuyer", userIdParameter);
        }
    
        public virtual ObjectResult<SP_OrderByBuyerInDetail_Result> SP_OrderByBuyerInDetail(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_OrderByBuyerInDetail_Result>("SP_OrderByBuyerInDetail", userIdParameter);
        }
    
        public virtual int SP_UpdateOrder(Nullable<int> orderId, Nullable<int> userId, Nullable<int> status, string shippingAddress, Nullable<int> quantity, Nullable<int> itemId, Nullable<int> productId)
        {
            var orderIdParameter = orderId.HasValue ?
                new ObjectParameter("orderId", orderId) :
                new ObjectParameter("orderId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            var shippingAddressParameter = shippingAddress != null ?
                new ObjectParameter("shippingAddress", shippingAddress) :
                new ObjectParameter("shippingAddress", typeof(string));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("quantity", quantity) :
                new ObjectParameter("quantity", typeof(int));
    
            var itemIdParameter = itemId.HasValue ?
                new ObjectParameter("itemId", itemId) :
                new ObjectParameter("itemId", typeof(int));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("productId", productId) :
                new ObjectParameter("productId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UpdateOrder", orderIdParameter, userIdParameter, statusParameter, shippingAddressParameter, quantityParameter, itemIdParameter, productIdParameter);
        }
    
        public virtual ObjectResult<SP_GetEmailIdOfuser_Result> SP_GetEmailIdOfuser(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetEmailIdOfuser_Result>("SP_GetEmailIdOfuser", userIdParameter);
        }
    }
}
