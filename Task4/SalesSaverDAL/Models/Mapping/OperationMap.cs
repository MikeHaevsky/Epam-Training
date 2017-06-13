using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesSaverDAL.Models.Mapping
{
    public class OperationMap : EntityTypeConfiguration<Operation>
    {
        public OperationMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.ToTable("Operations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.ManagerId).HasColumnName("ManagerId");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Cost).HasColumnName("Cost");

            this.HasRequired(t => t.Client)
                .WithMany(t => t.Operations)
                .HasForeignKey(d => d.ClientId);
            this.HasRequired(t => t.Manager)
                .WithMany(t => t.Operations)
                .HasForeignKey(d => d.ManagerId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Operations)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
