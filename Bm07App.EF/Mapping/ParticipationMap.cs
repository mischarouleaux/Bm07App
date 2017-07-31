using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class ParticipationMap : EntityTypeConfiguration<Participation>
    {
        public ParticipationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Participation");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ActivityId).HasColumnName("ActivityId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Activity)
                .WithMany(t => t.Participations)
                .HasForeignKey(d => d.ActivityId);

        }
    }
}
