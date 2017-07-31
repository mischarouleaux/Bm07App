using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class ClientNoteMap : EntityTypeConfiguration<ClientNote>
    {
        public ClientNoteMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Remark)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ClientNote");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ApplicationUserId).HasColumnName("ApplicationUserId");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateDateTime).HasColumnName("CreateDateTime");
            this.Property(t => t.UpdateDateTime).HasColumnName("UpdateDateTime");

            // Relationships
            this.HasRequired(t => t.ApplicationUser)
                .WithMany(t => t.ClientNotes)
                .HasForeignKey(d => d.ApplicationUserId);
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ClientNotes)
                .HasForeignKey(d => d.ClientId);

        }
    }
}
