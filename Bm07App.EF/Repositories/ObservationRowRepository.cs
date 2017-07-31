﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;
using Bm07App.Interfaces.Repositories;


namespace Bm07App.EF.Repositories
{
    public class ObservationRowRepository : BaseRepository<ObservationRow>, IObservationRowRepository
    {
        public ObservationRowRepository(CasusBM07Context context) : base(context)
        {

        }
    }
}
