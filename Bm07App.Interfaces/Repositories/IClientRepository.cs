using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetClientById(long clientId);

        /// <summary>
        /// Gets a client if the given client has any observation with the given id.
        /// This operation takes a while if the table is big
        /// Aks the Observation Table instead.
        /// </summary>
        /// <param name="observationId"></param>
        /// <returns></returns>
        Client GetClientByObservationId(long observationId);

        Observation GetObservation(Client client, long observationId);
    }
}
