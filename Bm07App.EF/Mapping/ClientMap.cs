using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstNameLetter)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BirthLastName)
                .HasMaxLength(50);

            this.Property(t => t.TelephoneNumber)
                .HasMaxLength(20);

            this.Property(t => t.MobileNumber)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.StreetName)
                .HasMaxLength(50);

            this.Property(t => t.StreetNumber)
                .HasMaxLength(10);

            this.Property(t => t.StreetNumberSuffix)
                .HasMaxLength(10);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Client");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstNameLetter).HasColumnName("FirstNameLetter");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.BirthLastName).HasColumnName("BirthLastName");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.TelephoneNumber).HasColumnName("TelephoneNumber");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.StreetName).HasColumnName("StreetName");
            this.Property(t => t.StreetNumber).HasColumnName("StreetNumber");
            this.Property(t => t.StreetNumberSuffix).HasColumnName("StreetNumberSuffix");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasMany(t => t.UserGroups)
                .WithMany(t => t.Clients)
                .Map(m =>
                    {
                        m.ToTable("Client_Group");
                        m.MapLeftKey("ClientId");
                        m.MapRightKey("GroupId");
                    });


        }
    }
}
