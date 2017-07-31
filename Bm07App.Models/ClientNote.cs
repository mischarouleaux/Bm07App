using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class ClientNote
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ApplicationUserId { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public System.DateTime UpdateDateTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Client Client { get; set; }
    }
}
