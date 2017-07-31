using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class Participation
    {
        public Participation()
        {
            this.Observations = new List<Observation>();
        }

        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
    }
}
