using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;
using Bm07App.Interfaces.Repositories;


namespace Bm07App.EF.Repositories
{
    public class ObservationRepository : BaseRepository<Observation>, IObservationRepository
    {
        public ObservationRepository(CasusBM07Context context) : base(context)
        {

        }
    }
}
