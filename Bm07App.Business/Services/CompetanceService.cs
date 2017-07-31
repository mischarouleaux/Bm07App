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
    public class CompetanceService : ICompetanceService
    {
        private readonly ICompetanceRepository _repository;
        private readonly IUnitOfWork _uow;

        public CompetanceService(ICompetanceRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        #region Methods

        public Competance GetCompetanceById(int id)
        {
            Competance a = _repository.Get(filter => filter.Id == id).FirstOrDefault();
            return a;
        }

        public bool AddCompetance(Competance competance)
        {
            if (_repository.Get(filter => filter.Name == competance.Name).Count() >= 1)
            {
                return false;
            }

            _repository.Add(competance);
            _uow.Commit();
            return true;
        }

        public bool EditCompetance(Competance competance)
        {
            if (_repository.Get(filter => filter.Name == competance.Name).Count() >= 1)
            {
                return false;
            }

            _repository.Edit(competance);
            _uow.Commit();

            return true;
        }

        public IQueryable<Competance> GetAllCompetance()
        {
            IQueryable<Competance> allCompetances = _repository.Get();
            return allCompetances;
        }

        #endregion
    }
}
