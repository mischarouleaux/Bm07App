using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class Case
    {
        public Case()
        {
            this.Observations = new List<Observation>();
        }

        public int Id { get; set; }
        public int CompetanceId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual Competance Competance { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
    }
}
