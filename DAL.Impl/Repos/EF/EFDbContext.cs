using DAL.Impl.Repos.EF.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DAL.Impl.Repos.EF
{
    internal class EFDbContext : DbContext
    {
        public EFDbContext() : base("FancyStoreDB")
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

            _ = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
    // Migrations are considered configured for MyDbContext because this class implementation exists.
    internal sealed class Configuration : DbMigrationsConfiguration<EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
