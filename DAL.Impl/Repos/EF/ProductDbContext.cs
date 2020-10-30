using DAL.Impl.Repos.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl.Repos.EF
{
    class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("FancyStoreDB")
        {

        }
        public DbSet<ClothingItem> Clothes { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }


        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
    // Migrations are considered configured for MyDbContext because this class implementation exists.
    internal sealed class Configuration : DbMigrationsConfiguration<ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
