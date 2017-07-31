using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class ApplicationUserClient
    {
        public int ApplicationUserId { get; set; }
        public int ClientId { get; set; }
        public System.DateTime JoinDateTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Client Client { get; set; }
    }
}
