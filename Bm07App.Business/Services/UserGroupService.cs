﻿using System;
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
    public class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _repository;
        private readonly IUnitOfWork _uow;

        public UserGroupService(IUserGroupRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        #region Methods



        #endregion
    }
}
