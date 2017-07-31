using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using Bm07App.Interfaces.Repositories;
using Bm07App.Interfaces.Services;
using Bm07App.Interfaces;
using Bm07App.Models;

namespace Bm07App.Business.Services
{
    public class ObservationService : IObservationService
    {
        private readonly IObservationRepository _repository;
        private readonly IUnitOfWork _uow;

        public ObservationService(IObservationRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        public void Add(Observation observation)
        {
            _repository.Add(observation);
            _uow.Commit();
        }

        public void Delete(Observation observation)
        {
            
        }

        public void Edit(Observation observation)
        {
            _repository.Edit(observation);
            _uow.Commit();
        }

        public Observation GetObservationById(int id)
        {
            return _repository.Get(filter => filter.Id == id).FirstOrDefault();
        }

        public List<Observation> GetObservationsByCase(int caseId)
        {
            return null;
        }

        public List<Observation> GetObservationsByClient(int clientId)
        {
            return null;//return _repository.Get(filter => filter.clientId == clientId).FirstOrDefault();
        }

        public List<Observation> GetObservationsByICF(int ICFId)
        {
            return null;
        }

        public List<Observation> GetObservationsBySubLocation(int subLocationId)
        {
            return null;
        }

        #region Methods


        #endregion
    }
}
