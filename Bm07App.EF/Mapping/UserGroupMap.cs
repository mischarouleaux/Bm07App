using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class UserGroupMap : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CompanyName)
                .HasMaxLength(100);

            this.Property(t => t.StreetName)
                .HasMaxLength(100);

            this.Property(t => t.StreetNumber)
                .HasMaxLength(10);

            this.Property(t => t.StreetNumberSuffix)
                .HasMaxLength(10);

            this.Property(t => t.City)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("UserGroup");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ApplicationUserId).HasColumnName("ApplicationUserId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.StreetName).HasColumnName("StreetName");
            this.Property(t => t.StreetNumber).HasColumnName("StreetNumber");
            this.Property(t => t.StreetNumberSuffix).HasColumnName("StreetNumberSuffix");
            this.Property(t => t.City).HasColumnName("City");

            // Relationships
            this.HasRequired(t => t.ApplicationUser)
                .WithMany(t => t.UserGroups)
                .HasForeignKey(d => d.ApplicationUserId);

        }
    }
}
