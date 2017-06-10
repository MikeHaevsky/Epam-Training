using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesSaverDAL.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Nickname)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Clients");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nickname).HasColumnName("Nickname");
        }
    }
}
