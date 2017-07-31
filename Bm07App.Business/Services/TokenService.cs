using Bm07App.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;
using Bm07App.Interfaces;
using Bm07App.Interfaces.Repositories;

namespace Bm07App.Business.Services
{
    class TokenService : ITokenService
    {
        //private readonly ITokenRepository _repository;
        private readonly IUnitOfWork _uow;

        private readonly TimeSpan sessionTokenDuration = TimeSpan.FromMinutes(10);

        public TokenService(/*ITokenRepository repo, */IUnitOfWork uow)
        {
            //_repository = repo;
            _uow = uow;
        }

        public string GetSessionToken(ApplicationUser user)
        {
            //SessionToken sessionToken = _repository.Get(sToken => sToken.User == user && (sToken.CreationDateTime + sessionTokenDuration) >= DateTime.Now).FirstOrDefault();
            SessionToken sessionToken = null;
            string token = sessionToken != null ? sessionToken.Token : /*this.GenerateNewSessionToken()*/ user.Id.ToString();

            // Save/update db with token:
            //_repository.InsertOrUpdate(user, token);

            return token;
        }

        /// <summary>
        /// @TEMP CLASS - REMOVE
        /// </summary>
        private class SessionToken
        {
            public string Token { get; set; }
        }
    }
}
