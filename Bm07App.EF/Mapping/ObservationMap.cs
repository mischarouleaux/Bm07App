using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class ObservationMap : EntityTypeConfiguration<Observation>
    {
        public ObservationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Observation");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.CaseId).HasColumnName("CaseId");
            this.Property(t => t.ParticipationId).HasColumnName("ParticipationId");
            this.Property(t => t.ICFId).HasColumnName("ICFId");
            this.Property(t => t.CreateDateTime).HasColumnName("CreateDateTime");
            this.Property(t => t.UpdateDateTime).HasColumnName("UpdateDateTime");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Case)
                .WithMany(t => t.Observations)
                .HasForeignKey(d => d.CaseId);
            this.HasRequired(t => t.Client)
                .WithMany(t => t.Observations)
                .HasForeignKey(d => d.ClientId);
            this.HasRequired(t => t.ICF)
                .WithMany(t => t.Observations)
                .HasForeignKey(d => d.ICFId);
            this.HasRequired(t => t.Participation)
                .WithMany(t => t.Observations)
                .HasForeignKey(d => d.ParticipationId);

        }
    }
}
