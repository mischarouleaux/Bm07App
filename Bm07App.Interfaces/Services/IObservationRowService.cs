using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface IObservationRowService
    {
        ObservationRow GetObservationRowById(int id);
        bool AddObservationRow(ObservationRow obsCase);
        bool EditObservationRow(ObservationRow obsCase);
        IQueryable<ObservationRow> GetFromObservationId(int observationId);
    }
}
