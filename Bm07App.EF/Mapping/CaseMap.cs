using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class CaseMap : EntityTypeConfiguration<Case>
    {
        public CaseMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Case");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompetanceId).HasColumnName("CompetanceId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Competance)
                .WithMany(t => t.Cases)
                .HasForeignKey(d => d.CompetanceId);

        }
    }
}
