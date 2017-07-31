using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class EmailTokenMap : EntityTypeConfiguration<EmailToken>
    {
        public EmailTokenMap()
        {
            // Primary Key
            this.HasKey(t => t.ApplicationUserId);

            // Properties
            this.Property(t => t.ApplicationUserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EmailToken1)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EmailToken");
            this.Property(t => t.ApplicationUserId).HasColumnName("ApplicationUserId");
            this.Property(t => t.EmailToken1).HasColumnName("EmailToken");

            // Relationships
            this.HasRequired(t => t.ApplicationUser)
                .WithOptional(t => t.EmailToken);

        }
    }
}
