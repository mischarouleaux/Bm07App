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
    public class CaseService : ICaseService
    {
        private readonly ICaseRepository _repository;
        private readonly IUnitOfWork _uow;
        private readonly ICompetanceRepository _competanceRepository;

        public CaseService(ICaseRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        #region Methods

        public Case GetCaseById(int id)
        {
            Case p = _repository.Get(filter => filter.Id == id).FirstOrDefault();

            if (p != null)
            {
                p.Competance = _competanceRepository.Get(filter => filter.Id == p.CompetanceId).FirstOrDefault();
            }

            return p;
        }

        public bool AddCase(Case participation)
        {
            if (_repository.Get(filter => filter.CompetanceId == participation.CompetanceId && filter.Name == participation.Name).Count() >= 1)
            {
                return false;
            }

            _repository.Add(participation);
            _uow.Commit();

            return true;
        }

        public bool EditCase(Case participation)
        {
            if (_repository.Get(filter => filter.CompetanceId == participation.CompetanceId && filter.Name == participation.Name).Count() >= 1)
            {
                return false;
            }

            _repository.Edit(participation);
            _uow.Commit();

            return true;
        }

        public IQueryable<Case> GetFromCompetanceId(int competanceId)
        {
            return _repository.Get(filter => filter.CompetanceId == competanceId);
        }

        #endregion
    }
}
