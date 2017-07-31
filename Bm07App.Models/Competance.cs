using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class Competance
    {
        public Competance()
        {
            this.Cases = new List<Case>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
    }
}
