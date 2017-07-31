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
    public class ParticipationService : IParticipationService
    {
        private readonly IParticipationRepository _repository;
        private readonly IActivityRepository _activityRepository;
        private readonly IUnitOfWork _uow;

        public ParticipationService(IParticipationRepository repo, IActivityRepository activityRepository, IUnitOfWork uow)
        {
            _repository = repo;
            _activityRepository = activityRepository;
            _uow = uow;
        }

        #region Methods

        public Participation GetParticipationById(int id)
        {
            Participation p = _repository.Get(filter => filter.Id == id).FirstOrDefault();

            if(p != null)
            {
                p.Activity = _activityRepository.Get(filter => filter.Id == p.ActivityId).FirstOrDefault();
            }
            
            return p;
        }

        public bool AddParticipation(Participation participation)
        {
            if(_repository.Get(filter => filter.ActivityId == participation.ActivityId && filter.Name == participation.Name).Count() >= 1)
            {
                return false;
            }
               
            _repository.Add(participation);
            _uow.Commit();
            
            return true;
        }

        public bool EditParticipation(Participation participation)
        {
            if (_repository.Get(filter => filter.ActivityId == participation.ActivityId && filter.Name == participation.Name).Count() >= 1)
            {
                return false;
            }

            _repository.Edit(participation);
            _uow.Commit();

            return true;
        }

        public IQueryable<Participation> GetParticipationFromActivityId(int activityId)
        {
            return _repository.Get(filter => filter.ActivityId == activityId);
        }

        #endregion
    }
}
