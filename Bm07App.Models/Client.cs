using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class Client
    {
        public Client()
        {
            this.ApplicationUserClients = new List<ApplicationUserClient>();
            this.ClientNotes = new List<ClientNote>();
            this.Observations = new List<Observation>();
            this.UserGroups = new List<UserGroup>();
        }

        public int Id { get; set; }
        public string FirstNameLetter { get; set; }
        public string LastName { get; set; }
        public string BirthLastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetNumberSuffix { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<ApplicationUserClient> ApplicationUserClients { get; set; }
        public virtual ICollection<ClientNote> ClientNotes { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
