using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Bm07App.Interfaces.Repositories;
using Bm07App.Interfaces.Services;
using Bm07App.Interfaces;
using Bm07App.Models;

namespace Bm07App.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IUnitOfWork _uow;

        public ClientService()
        {
        }

        public ClientService(IClientRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        #region Methods

        public Client GetClientById(int id)
        {
            return _repository.Get(filter => filter.Id == id).FirstOrDefault();
        }
        public void Add(Client client)
        { 
            _repository.Add(client);
            _uow.Commit();
        }
            

        public void ChangeActive(int id)
        {
            Client client = GetClientById(id);

            if (client.Active == true)
            {
                client.Active = false;
            }

            else
            {
                client.Active = true;
            }

            Save(client);
            
        }

        public List<Client> GetAll()
        {
            return _repository.Get().ToList();
        }


        public void Save(Models.Client client)
        {
            using (_uow)
            {
                if (client.Id == null)
                {
                    _repository.Add(client);
                }
                else
                {
                    _repository.Edit(client);
                }

                _uow.Commit();
            }
            
        }
    
        #endregion

        public void Edit(Client client)
        {
             
            _repository.Edit(client);
            _uow.Commit();

        }


        /// <summary>
        /// Gets obervations of the client with the given client id.
        /// <para>Throws <see cref="ArgumentException"/> and <see cref="ArgumentNullException"/>.</para>
        /// </summary>
        /// <param name="user">The user who tries to get the observations</param>
        /// <param name="clientId">The client whose observations are requested</param>
        /// <returns></returns>
        public Observation[] GetObservations(ApplicationUser user, long clientId)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            //this.InsertTestClient();

            Client client = _repository.GetClientById(clientId);
            if (this.IsAuthenticated(user, client))
            {
                return client.Observations.ToArray();
            }

            throw new ArgumentException(
                $"The given user (UserId: {user.Id}) has no authorisation to get the clients observations or the client does not exist, clientId: {clientId}",
                "user and clientId");
        }

        public Client[] GetClients(ApplicationUser user)
        {
            // Hopelijk is dit goed
            // Als de mensen van de db het nu eens goed hadden opgezet
            return _repository.Get(client => from userClient in client.ApplicationUserClients
                                             where userClient.ApplicationUser.Id == user.Id
                                             select client, include => include.Observations).ToArray();
        }

        private bool IsAuthenticated(ApplicationUser user, Client client)
        {
            if (user == null || client == null)
            {
                return false;
            }

            // We get the user from the database to authenticate
            // If we get a user it means that that user may access the given client id
            // If we get a null value it means that the user is not allowed to have access
            ApplicationUser dbUser = (from appUserClient in client.ApplicationUserClients
                                      where appUserClient.ApplicationUser.Id == user.Id
                                      select appUserClient.ApplicationUser).FirstOrDefault();
            return dbUser != null;
        }
    }
}
