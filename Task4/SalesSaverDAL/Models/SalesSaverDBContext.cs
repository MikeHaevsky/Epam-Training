using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SalesSaverDAL.Models.Mapping;

namespace SalesSaverDAL.Models
{
    public partial class SalesSaverDBContext : DbContext
    {
        static SalesSaverDBContext()
        {
            Database.SetInitializer<SalesSaverDBContext>(null);
        }

        public SalesSaverDBContext()
            : base("Name=SalesSaverDBContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ManagerMap());
            modelBuilder.Configurations.Add(new OperationMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
