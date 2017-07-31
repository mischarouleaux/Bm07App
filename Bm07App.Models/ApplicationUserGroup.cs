using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class ApplicationUserGroup
    {
        public int ApplicationUserId { get; set; }
        public int GroupId { get; set; }
        public System.DateTime JoinDateTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
