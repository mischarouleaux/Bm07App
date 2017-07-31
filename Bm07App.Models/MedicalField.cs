using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class MedicalField
    {
        public MedicalField()
        {
            this.ApplicationUsers = new List<ApplicationUser>();
        }

        public int Id { get; set; }
        public string FieldName { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
