using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;
using Bm07App.Interfaces.Repositories;

namespace Bm07App.EF.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(CasusBM07Context context) : base(context)
        {

        }

        public Client GetClientById(long clientId)
        {
            return this.Get(client => client.Id == clientId, include => include.Observations).FirstOrDefault();
        }

        /// <summary>
        /// Gets a client if the given client has any observation with the given id.
        /// This operation takes a while if the table is big
        /// Aks the Observation Table instead.
        /// </summary>
        /// <param name="observationId"></param>
        /// <returns></returns>
        public Client GetClientByObservationId(long observationId)
        {
            // Gets a client if the given client has any observation with the given id.
            // This operation takes a while if the table is big
            // Aks the Observation Table instead.
            return (from client in this.Get()
                    where client.Observations.Where(obser => obser.Id == observationId).Any()
                    select client).FirstOrDefault();
        }

        public Observation GetObservation(Client client, long observationId)
        {
            return client.Observations.Where(observation => observation.Id == observationId).FirstOrDefault();
        }
    }
}
