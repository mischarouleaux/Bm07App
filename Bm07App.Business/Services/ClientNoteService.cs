using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Interfaces.Repositories;
using Bm07App.Interfaces.Services;
using Bm07App.Interfaces;
using Bm07App.Models;

namespace Bm07App.Business.Services
{
    public class ClientNoteService : IClientNoteService
    {
        private readonly IClientNoteRepository _repository;
        private readonly IUnitOfWork _uow;

        public ClientNoteService(IClientNoteRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        public void Add(ClientNote clientNote)
        {
            _repository.Add(clientNote);
            _uow.Commit();
        }

        public void Delete(ClientNote clientNote)
        {
            
        }

        public void Edit(ClientNote clientNote)
        {
            _repository.Edit(clientNote);
            _uow.Commit();
        }

        public ClientNote GetClientNoteById(int id)
        {
            return _repository.Get(filter => filter.Id == id).FirstOrDefault();
        }

        public List<ClientNote> GetClientNotesByClientId(int clientId)
        {
            List<ClientNote> clientNoteList = new List<ClientNote>();
            List<int> foundIds = new List<int>();
            bool done = false;
            while (!done) {
                ClientNote getClientNote = _repository.Get(filter => filter.ClientId == clientId, l => !foundIds.Contains(l.Id)).FirstOrDefault();
                if (getClientNote != null) {
                    clientNoteList.Add(getClientNote);
                    foundIds.Add(getClientNote.Id);
                } else
                {
                    done = true;
                }
            }
            return clientNoteList;
        }

        #region Methods


        #endregion
    }
}
