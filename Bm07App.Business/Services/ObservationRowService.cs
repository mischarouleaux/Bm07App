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
    public class ObservationRowService : IObservationRowService
    {
        private readonly IObservationRowRepository _repository;
        private readonly IObservationRepository _observationRepository;
        private readonly IUnitOfWork _uow;

        public ObservationRowService(IObservationRowRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        #region Methods

        public ObservationRow GetObservationRowById(int observationRowId)
        {
            ObservationRow returnRow = _repository.Get(filter => filter.Id == observationRowId).FirstOrDefault();

            if (returnRow != null)
            {
                returnRow.Observation = _observationRepository.Get(filter => filter.Id == returnRow.ObservationId).FirstOrDefault();
            }

            return returnRow;
        }

        public bool AddObservationRow(ObservationRow rowToAdd)
        {
            _repository.Add(rowToAdd);
            _uow.Commit();

            return true;
        }

        public bool EditObservationRow(ObservationRow rowToEdit)
        {
            _repository.Edit(rowToEdit);
            _uow.Commit();

            return true;
        }

        public IQueryable<ObservationRow> GetFromObservationId(int observationId)
        {
            return _repository.Get(filter => filter.ObservationId == observationId);
        }
        #endregion
    }
}
