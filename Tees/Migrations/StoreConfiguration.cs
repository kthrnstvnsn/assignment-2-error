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
        }
    }
}
