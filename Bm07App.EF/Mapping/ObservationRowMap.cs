using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class ObservationRowMap : EntityTypeConfiguration<ObservationRow>
    {
        public ObservationRowMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ObservationRow");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ObservationId).HasColumnName("ObservationId");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateDateTime).HasColumnName("CreateDateTime");
            this.Property(t => t.UpdateDateTime).HasColumnName("UpdateDateTime");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Persoon).HasColumnName("Persoon");
            this.Property(t => t.Emotie).HasColumnName("Emotie");
            this.Property(t => t.Omgeving).HasColumnName("Omgeving");

            // Relationships
            this.HasRequired(t => t.Observation)
                .WithMany(t => t.ObservationRows)
                .HasForeignKey(d => d.ObservationId);

        }
    }
}
