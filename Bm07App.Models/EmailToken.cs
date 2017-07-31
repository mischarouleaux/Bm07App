using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class EmailToken
    {
        public int ApplicationUserId { get; set; }
        public string EmailToken1 { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
