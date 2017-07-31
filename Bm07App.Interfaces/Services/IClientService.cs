using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface IClientService
    {
        void Add(Client client);
        void Edit(Client client);


        Client GetClientById(int id);
        void ChangeActive(int id);
        List<Client> GetAll();
        void Save(Models.Client client);
        Observation[] GetObservations(ApplicationUser user, long clientId);
        Client[] GetClients(ApplicationUser user);
    }
}
