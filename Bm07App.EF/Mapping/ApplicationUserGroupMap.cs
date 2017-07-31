using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class ApplicationUserGroupMap : EntityTypeConfiguration<ApplicationUserGroup>
    {
        public ApplicationUserGroupMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ApplicationUserId, t.GroupId });

            // Properties
            this.Property(t => t.ApplicationUserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GroupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ApplicationUserGroup");
            this.Property(t => t.ApplicationUserId).HasColumnName("ApplicationUserId");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.JoinDateTime).HasColumnName("JoinDateTime");

            // Relationships
            this.HasRequired(t => t.ApplicationUser)
                .WithMany(t => t.ApplicationUserGroups)
                .HasForeignKey(d => d.ApplicationUserId);
            this.HasRequired(t => t.UserGroup)
                .WithMany(t => t.ApplicationUserGroups)
                .HasForeignKey(d => d.GroupId);

        }
    }
}
