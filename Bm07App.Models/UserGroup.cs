using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            this.ApplicationUserGroups = new List<ApplicationUserGroup>();
            this.Clients = new List<Client>();
        }

        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string Name { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string CompanyName { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetNumberSuffix { get; set; }
        public string City { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
