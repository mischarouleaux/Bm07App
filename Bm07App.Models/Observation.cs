using System;
using System.Collections.Generic;

namespace Bm07App.Models
{
    public partial class Observation
    {
        public Observation()
        {
            this.ObservationRows = new List<ObservationRow>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CaseId { get; set; }
        public int ParticipationId { get; set; }
        public int ICFId { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public System.DateTime UpdateDateTime { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Rating { get; set; }
        public bool Active { get; set; }
        public virtual Case Case { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICF ICF { get; set; }
        public virtual ICollection<ObservationRow> ObservationRows { get; set; }
        public virtual Participation Participation { get; set; }
    }
}
