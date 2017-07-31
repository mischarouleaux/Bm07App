using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class SessionTokenMap : EntityTypeConfiguration<SessionToken>
    {
        public SessionTokenMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Token)
                .IsRequired()
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("SessionToken");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ApplicationUserId).HasColumnName("ApplicationUserId");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.LastUsed).HasColumnName("LastUsed");

            // Relationships
            this.HasRequired(t => t.ApplicationUser)
                .WithMany(t => t.SessionTokens)
                .HasForeignKey(d => d.ApplicationUserId);

        }
    }
}
