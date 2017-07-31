using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class ObservationRow
    {
        public int Id { get; set; }
        public int ObservationId { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public System.DateTime UpdateDateTime { get; set; }
        public bool Active { get; set; }
        public bool Persoon { get; set; }
        public bool Emotie { get; set; }
        public bool Omgeving { get; set; }
        public virtual Observation Observation { get; set; }
    }
}
