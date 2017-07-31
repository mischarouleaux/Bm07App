using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class SessionToken
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string Token { get; set; }
        public System.DateTime LastUsed { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
