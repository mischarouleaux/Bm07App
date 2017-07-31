using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Interfaces.Repositories;
using Bm07App.Interfaces.Services;
using Bm07App.Interfaces;
using Bm07App.Models;
using System.Security.Cryptography;

namespace Bm07App.Business.Services
{
    public class SessionTokenService : ISessionTokenService
    {
        private readonly ISessionTokenRepository _repository;
        private readonly IUnitOfWork _uow;

        private readonly TimeSpan SessionTokenLifespan = true ? TimeSpan.FromMinutes(10) : TimeSpan.FromSeconds(1); // For debugging
        private readonly int TokenLength = 50;

        public SessionTokenService(ISessionTokenRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        public string GetSessionToken(ApplicationUser user)
        {
            SessionToken sessionToken = _repository.Get(sToken => sToken.ApplicationUser.Id == user.Id).FirstOrDefault();

            if (sessionToken == null)
            {
                sessionToken = this.CreateNewSessionToken(user);
            }
            else
            {
                sessionToken = this.UpdateSessionToken(sessionToken);
            }

            if (!this.IsValidSessionToken(sessionToken))
            {
                throw new InvalidOperationException(
                    "Something went wrong when retrieving a session token for a application user." +
                    "A valid session token could not have been generated or updated." +
                    $"Session token: IsNull: {sessionToken == null}, Token: {(sessionToken != null ? sessionToken.Token : string.Empty)}" +
                    $"ApplicationUser Id: {user.Id}"
                    );
            }

            return sessionToken.Token;
        }

        private SessionToken CreateNewSessionToken(ApplicationUser user)
        {
            SessionToken sessionToken = new SessionToken
            {
                ApplicationUser = user,
                Token = this.GenerateSessionToken(this.TokenLength),
                LastUsed = DateTime.Now
            };

            sessionToken = _repository.Add(sessionToken);
            _uow.CommitAsync(); // Just in case

            return sessionToken;
        }

        private SessionToken UpdateSessionToken(SessionToken sessionToken)
        {
            if (sessionToken == null)
            {
                throw new ArgumentNullException("sessionToken");
            }

            // Generate a new session token string if the current session is not valid
            if (!this.IsValidSessionToken(sessionToken))
            {
                sessionToken.Token = this.GenerateSessionToken(this.TokenLength);
            }

            sessionToken.LastUsed = DateTime.Now;
            sessionToken = _repository.Edit(sessionToken);
            _uow.CommitAsync();

            return sessionToken;
        }

        /// <summary>
        /// Gets an user by its current session token. If the provided session token is not valid, <see cref="ArgumentException"/> is raised.
        /// <para>
        /// Throws <see cref="ArgumentException"/>.
        /// </para>
        /// </summary>
        /// <param name="sessionToken">The session token of the user</param>
        /// <returns></returns>
        public ApplicationUser GetUserByToken(string sessionToken)
        {
            SessionToken sToken = _repository.Get(token => token.Token == sessionToken, include => include.ApplicationUser).FirstOrDefault();

            if (this.IsValidSessionToken(sToken))
            {
                ApplicationUser user = sToken.ApplicationUser;
                sToken.LastUsed = DateTime.Now;
                _repository.Edit(sToken);
                _uow.CommitAsync();
                return user;
            }

            throw new ArgumentException($"The provided SessionToken is currently not in use. SessionToken provided: {sessionToken}.", "sessionToken");
        }

        /// <summary>
        /// For more information see: http://codereview.stackexchange.com/questions/93614/salt-generation-in-c
        /// Generates a base64 random string.
        /// </summary>
        /// <param name="length">The length of the token</param>
        /// <returns></returns>
        private string GenerateSessionToken(int length)
        {
            string token = null;

            do
            {
                byte[] tokenBytes = new byte[length];

                using (var rngCryptoSerivceProvider = new RNGCryptoServiceProvider())
                {
                    rngCryptoSerivceProvider.GetNonZeroBytes(tokenBytes);
                }

                // Add the System.Web dll in reference in project.
                // Method from: https://msdn.microsoft.com/en-us/library/system.web.httpserverutility.urltokenencode.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1
                token = System.Web.HttpServerUtility.UrlTokenEncode(tokenBytes);

                // Do this as long as we generate a token that already exists. 
                // Event on a duplicate, it should not happen to often that a duplicate is generated at a decent length!
            } while (_repository.Get(sToken => sToken.Token == token).FirstOrDefault() != null);

            return token;
        }

        private bool IsValidSessionToken(SessionToken token)
        {
            // If the last used datetime plus the lifespan is greater than current datetime,
            // it means that the token is still within its lifespan (and thus valid).
            return token != null && !string.IsNullOrWhiteSpace(token.Token) && token.LastUsed.Add(this.SessionTokenLifespan) >= DateTime.Now && token.ApplicationUser != null;
        }

        public bool InvalidateToken(string sessionToken)
        {
            if (sessionToken == null)
            {
                throw new ArgumentNullException("sessionToken");
            }

            if (string.IsNullOrWhiteSpace(sessionToken))
            {
                throw new ArgumentException("SessionToken can not be null, empty or whitespace.", "sessionToken");
            }

            SessionToken sToken = _repository.Get(token => token.Token == sessionToken).FirstOrDefault();
            if (sToken != null)
            {
                sToken.LastUsed = DateTime.Now.Subtract(this.SessionTokenLifespan);
                _repository.Edit(sToken);
                _uow.CommitAsync();
                return true;
            }

            return false;
        }
    }
}

