using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebBanHang.Models.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebBanHang.Identity;

namespace WebBanHang.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() : base("conn")
        {

        }
        public static MyDbContext Create()
        {
            return new MyDbContext();
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }
    }
}