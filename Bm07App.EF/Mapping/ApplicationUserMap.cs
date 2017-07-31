using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class ApplicationUserMap : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(26);

            this.Property(t => t.Password)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2048);

            this.Property(t => t.NameTitle)
                .HasMaxLength(10);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.WorkEmail)
                .HasMaxLength(100);

            this.Property(t => t.WorkTelephoneNumber)
                .HasMaxLength(20);

            this.Property(t => t.MobileTelephoneNumber)
                .HasMaxLength(20);

            this.Property(t => t.BigNummer)
                .HasMaxLength(20);

            this.Property(t => t.Functie)
                .HasMaxLength(100);

            this.Property(t => t.HighestDiploma)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ApplicationUser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MedicalFieldId).HasColumnName("MedicalFieldId");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.RegisterDateTime).HasColumnName("RegisterDateTime");
            this.Property(t => t.NameTitle).HasColumnName("NameTitle");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.WorkEmail).HasColumnName("WorkEmail");
            this.Property(t => t.WorkTelephoneNumber).HasColumnName("WorkTelephoneNumber");
            this.Property(t => t.MobileTelephoneNumber).HasColumnName("MobileTelephoneNumber");
            this.Property(t => t.BigNummer).HasColumnName("BigNummer");
            this.Property(t => t.Functie).HasColumnName("Functie");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.HighestDiploma).HasColumnName("HighestDiploma");
            this.Property(t => t.VerifiedEmail).HasColumnName("VerifiedEmail");

            // Relationships
            this.HasRequired(t => t.MedicalField)
                .WithMany(t => t.ApplicationUsers)
                .HasForeignKey(d => d.MedicalFieldId);

        }
    }
}
