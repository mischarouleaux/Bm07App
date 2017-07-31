using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface IObservationService
    {
        void Add(Observation observation);
        void Edit(Observation observation);
        void Delete(Observation observation);

        Observation GetObservationById(int id);
        List<Observation> GetObservationsByClient(int clientId);
        List<Observation> GetObservationsByCase(int caseId);
        List<Observation> GetObservationsBySubLocation(int subLocationId);
        List<Observation> GetObservationsByICF(int ICFId);



    }
}
