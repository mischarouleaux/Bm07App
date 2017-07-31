using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class ApplicationUserClientMap : EntityTypeConfiguration<ApplicationUserClient>
    {
        public ApplicationUserClientMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ApplicationUserId, t.ClientId });

            // Properties
            this.Property(t => t.ApplicationUserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ApplicationUserClient");
            this.Property(t => t.ApplicationUserId).HasColumnName("ApplicationUserId");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.JoinDateTime).HasColumnName("JoinDateTime");

            // Relationships
            this.HasRequired(t => t.ApplicationUser)
                .WithMany(t => t.ApplicationUserClients)
                .HasForeignKey(d => d.ApplicationUserId);
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ApplicationUserClients)
                .HasForeignKey(d => d.ClientId);

        }
    }
}
