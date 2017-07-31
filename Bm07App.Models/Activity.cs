using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class Activity
    {
        public Activity()
        {
            this.Participations = new List<Participation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Participation> Participations { get; set; }
    }
}
