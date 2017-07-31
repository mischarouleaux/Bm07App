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
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _repository;
        private readonly IUnitOfWork _uow;

        public ActivityService(IActivityRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        #region Methods

        public Activity GetActivityById(int id)
        {
            Activity a = _repository.Get(filter => filter.Id == id).FirstOrDefault();
            return a;
        }

        public bool AddActivity(Activity activity)
        {
            if(_repository.Get(filter => filter.Name == activity.Name).Count() >= 1)
            {
                return false;
            }

            _repository.Add(activity);
            _uow.Commit();
            return true;
        }

        public bool EditActivity(Activity activity)
        {
            if (_repository.Get(filter => filter.Name == activity.Name).Count() >= 1)
            {
                return false;
            }
            
            _repository.Edit(activity);
            _uow.Commit();

            return true;
        }

        public IQueryable<Activity> GetAllActivity()
        {
            return _repository.Get();
        }


        #endregion
    }
}
