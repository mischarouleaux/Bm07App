using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bm07App.Models;

namespace Bm07App.EF.Mapping
{
    public class MedicalFieldMap : EntityTypeConfiguration<MedicalField>
    {
        public MedicalFieldMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FieldName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MedicalField");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FieldName).HasColumnName("FieldName");
        }
    }
}
