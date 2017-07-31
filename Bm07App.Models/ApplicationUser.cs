using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            this.ApplicationUserClients = new List<ApplicationUserClient>();
            this.ApplicationUserGroups = new List<ApplicationUserGroup>();
            this.ClientNotes = new List<ClientNote>();
            this.SessionTokens = new List<SessionToken>();
            this.UserGroups = new List<UserGroup>();
        }

        public int Id { get; set; }
        public int MedicalFieldId { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public System.DateTime RegisterDateTime { get; set; }
        public string NameTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string WorkEmail { get; set; }
        public string WorkTelephoneNumber { get; set; }
        public string MobileTelephoneNumber { get; set; }
        public string BigNummer { get; set; }
        public string Functie { get; set; }
        public bool Active { get; set; }
        public string HighestDiploma { get; set; }
        public bool VerifiedEmail { get; set; }
        public virtual ICollection<ApplicationUserClient> ApplicationUserClients { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        public virtual MedicalField MedicalField { get; set; }
        public virtual ICollection<ClientNote> ClientNotes { get; set; }
        public virtual EmailToken EmailToken { get; set; }
        public virtual ICollection<SessionToken> SessionTokens { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
