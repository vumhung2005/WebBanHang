namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebBanHang.Models.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<WebBanHang.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebBanHang.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.categories.AddOrUpdate(c => c.Name,
                new Category { Name=  "Thiết bị điện tử" },
                new Category { Name = "Laptop "},
                new Category { Name = "Phụ kiện"},
                new Category { Name = "Tablet"}
            );
            context.SaveChanges();

            var phone = context.categories.FirstOrDefault(c => c.Name == "Thiết bị điện tử");
            var laptop = context.categories.FirstOrDefault(c => c.Name == "Laptop");
            var accessory = context.categories.FirstOrDefault(c => c.Name == "Phụ kiện");
            var tablet = context.categories.FirstOrDefault(c => c.Name == "Tablet");


            context.products.AddOrUpdate(p => p.Name,
                new Product
                {
                    Name = "iPhone 14",
                    Price = 25000000,
                    Quantity = 10,
                    Image = "iphone14.jpg",
                    CategoryId = phone.Id
                },

                new Product
                {
                    Name =  "LaptopDell",
                    Price = 20000000,
                    Quantity = 10,
                    Image = "laptop.jpg",
                    CategoryId = laptop.Id
                },
                 new Product
                 {
                     Name = "Tai nghe AirPods Pro",
                     Price = 6000000,
                     Quantity = 15,
                     Image = "airpods.jpg",
                     CategoryId = accessory.Id
                 },
                  new Product
                  {
                      Name = "iPad Pro",
                      Price = 25000000,
                      Quantity = 6,
                      Image = "ipad.jpg",
                      CategoryId = tablet.Id
                  }



            );

        }
    }
}
