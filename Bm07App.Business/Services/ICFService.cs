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
    public class ICFService : IICFService
    {
        private readonly IICFRepository _repository;
        private readonly IUnitOfWork _uow;

        public ICFService(IICFRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }
        
        #region Methods
        
        public List<ICF> GetAllICF()
        {
            return _repository.Get().ToList();

        }

        public ICF GetICF(long id)
        {
            return _repository.Get(filter => filter.Id == id).FirstOrDefault();

        }

        public void AddICF(ICF icf)
        {
            _repository.Add(icf);
            _uow.Commit();
        }

        public void EditICF(ICF icf)
        {
            _repository.Edit(icf);
            _uow.Commit();
        }

        #endregion
    }
}
