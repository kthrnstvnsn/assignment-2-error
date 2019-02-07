namespace Tees.Migrations.StoreConfiguration
{
    using Models;
    using System.Collections.Generic;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class StoreConfiguration : DbMigrationsConfiguration<Tees.DAL.StoreContext>
    {
        public StoreConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tees.DAL.StoreContext context)
        {
            var categories = new List<Category>
                {
                new Category { Name = "Long Sleeve" },
                new Category { Name = "Short Sleeve" },
                new Category { Name = "Tanks" },
                };

            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Name = "Scoop Neck Blue Tee", Description="Blue long sleeve tee with a scoop neck", Price=79.99M, CategoryID=categories.Single( c => c.Name == "Long Sleeve").ID },
                new Product { Name = "Ice Blue Tee", Description="High necked long sleeve ice blue tee", Price=79.99M, CategoryID=categories.Single( c => c.Name == "Long Sleeve").ID },
                new Product { Name = "Fuzzy Pink Tee", Description="Crew neck long sleeve pink tee", Price=79.99M, CategoryID=categories.Single( c => c.Name == "Long Sleeve").ID },
                new Product { Name = "Navy Tank", Description="Easy to wear navy tank top", Price=39.99M, CategoryID=categories.Single( c => c.Name == "Tanks").ID },
                new Product { Name = "Rainbow Tank", Description="White muscle tank with rainbow on from", Price=39.99M, CategoryID=categories.Single( c => c.Name == "Tanks").ID },
                new Product { Name = "White Tank", Description="Basic white tank top", Price=39.99M, CategoryID=categories.Single( c => c.Name == "Tanks").ID },
            };

            products.ForEach(c => context.Products.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var orders = new List<Order>
             {
                new Order { DeliveryAddress = new Address { AddressLine1="One Street", Town="One Town", County="One County", Postcode="12345" }, TotalPrice=79.99M, UserID="one@customer.com", DateCreated=new DateTime(2018, 1, 3) , DeliveryName="Users" },
                new Order { DeliveryAddress = new Address { AddressLine1="One Street", Town="One Town", County="One County", Postcode="12345" }, TotalPrice=39.99M, UserID="one@customer.com", DateCreated=new DateTime(2019, 2, 1) , DeliveryName="Users" },
                new Order { DeliveryAddress = new Address { AddressLine1="1 Admin Street", Town="Admin Town", County="Admin County", Postcode="Admin PostCode" }, TotalPrice=79.99M, UserID="admin@tees.com", DateCreated=new DateTime(2018, 12, 5) , DeliveryName="Admin" }
             };

            orders.ForEach(c => context.Orders.AddOrUpdate(o => o.DateCreated, c));
            context.SaveChanges();

            var orderLines = new List<OrderLine>
            {
                new OrderLine { OrderID = 1, ProductID = products.Single( c=> c.Name == "Fuzzy Pink Tee").ID, ProductName="Fuzzy Pink Tee", Quantity=1, UnitPrice=products.Single( c=> c.Name == "Fuzzy Pink Tee").Price },
                new OrderLine { OrderID = 2, ProductID = products.Single( c=> c.Name == "Navy Tank").ID, ProductName="Navy Tank", Quantity=1, UnitPrice=products.Single( c=> c.Name == "Navy Tank").Price },
                new OrderLine { OrderID = 3, ProductID = products.Single( c=> c.Name == "Scoop Neck Blue Tee").ID, ProductName="Scoop Neck Blue Tee", Quantity=1, UnitPrice=products.Single( c=> c.Name == "Scoop Neck Blue Tee").Price }
            };

            orderLines.ForEach(c => context.OrderLines.AddOrUpdate(ol => ol.OrderID, c));
            context.SaveChanges();
        }
    }
}
