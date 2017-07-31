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
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;
        private readonly IUnitOfWork _uow;

        public ApplicationUserService(IApplicationUserRepository repo, IUnitOfWork uow)
        {
            _repository = repo;
            _uow = uow;
        }

        public IQueryable<ApplicationUser> GetAllUsers()
        {
            IQueryable<ApplicationUser> userlist = _repository.Get();
            int listLength = userlist.Count();
            int i = 0;
            
            return userlist;
        }

        /// <summary>
        /// g=Generates a random token
        /// </summary>
        /// <param name="length">The length of the token</param>
        /// <returns>A token with the specified length</returns>
        private string GenerateToken(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder token = new StringBuilder();
            Random random = new Random();
            while (0 < length--)
            {
                token.Append(chars[random.Next(chars.Length)]);
            }
            return token.ToString();
        }

        private async void SendVerification(string userEmail, string token)
        {

            /*
            var sender = "Zuyd"; //verzender nog toevoegen 
            var template = TestProject.Business.Properties.Resources.VerificationMail;
            var subject = "Please verify your Email";
            var message = (template.Replace(MailTemplate.Token, token));
            MailHelper mailHelper = new MailHelper();
            await mailHelper.sendAsync(sender, userEmail, subject, message);
            */
        }
        

        /// <summary>
        /// Verifies the token with the one in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool Verify(string username, string token)
        {
            ApplicationUser user = _repository.Get(filter => filter.UserName == username).FirstOrDefault(); //get user from db
            if (user != null)
            {
                //get token from db
                string dbUserToken = user.UserName; //verander dit naar token
                if (token == dbUserToken)
                {
                    //user.VerifiedEmail = true;
                    //remove token
                    _repository.Edit(user);
                    _uow.Commit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        
        

        public ApplicationUser GetApplicationUserById(int id)
        {
            return _repository.Get(appUser => appUser.Id == id).FirstOrDefault();
        }
       

        public void validateUser(int id, bool active)
        {
            ApplicationUser User = GetApplicationUserById(id);

            if (active == true)
            {
                User.Active = true;
            }

            if (active == false)
            {
                User.Active = false;
            }

            using (_uow)
            {
                _repository.Edit(User);

                _uow.Commit();
            }

        }

        public ApplicationUser GetUserByCredentials(string username, string password)
        {
            try
            {
                //this.InsertTestUser(hashedPassword);
                byte[] hashedPassword = Helpers.Hasher.HashString(password);

                // If something (even bool) is returned, the caller would know the username and password anyways.
                return _repository.Get(appUser => appUser.UserName == username && appUser.Password == hashedPassword && appUser.Active).FirstOrDefault();

            }
            catch (Exception e)
            {
                var ex = e;
                return null;
            }
        }

        /// <summary>
        /// Tries to lock an account by checking wheter the requesting user has the permissions and the account has nog been locked yet.
        /// <para>
        /// Throws <see cref="ArgumentException"/> and <see cref="ArgumentNullException"/>.
        /// </para>
        /// </summary>
        /// <param name="requestingUser">The user who wants to lock another account (or its own account)</param>
        /// <param name="accountIdToLock">The account id to lock</param>
        /// <returns></returns>
        public bool TryLock(ApplicationUser requestingUser, long accountIdToLock)
        {
            throw new NotImplementedException("Check whether the requesting user has the rights to lock an account.");

            if (requestingUser == null)
            {
                throw new ArgumentNullException("requestingUser");
            }

            ApplicationUser userToLock = _repository.Get(usr => usr.Id == accountIdToLock).FirstOrDefault();

            if (userToLock == null)
            {
                throw new ArgumentException($"Specified user with id {accountIdToLock} does not exist.");
            }

            if (requestingUser.Active && !userToLock.Active)
            {
                _repository.SoftDelete(userToLock);
                _uow.CommitAsync();
                return true;
            }

            return false;
        }

        public bool UpdateUser(ApplicationUser user, string password)
        {
            if (user.Id == 0)
            {
                //user.Token = GenerateToken(4);
                //_repository.Add(Token)
                user.Password = Helpers.Hasher.HashString(password);
                //string link = GenerateLink(user.UserName, user.Token);
                //SendVerification(user.WorkEmail, link);
                _repository.Add(user);
                _uow.Commit();
                return true;
            }
            else
            {
                if (user.Password.ToString() != password)//check whether the password changed
                {
                    user.Password = Helpers.Hasher.HashString(password);
                }
                _repository.Edit(user);
                _uow.Commit();
                return true;
            }
        }

        public string[] GetAllUserNames()
        {
            List<ApplicationUser> userlist = _repository.Get().ToList();
            int listLength = userlist.Count;
            int i = 0;
            string[] userArray = new string[listLength];
            foreach (ApplicationUser user in userlist)
            {
                userArray[i] = user.UserName;
                i++;
            }
            return userArray;
        }
        public ApplicationUser GetUser(string username)
        {
            return _repository.Get(filter => filter.UserName == username).FirstOrDefault();
        }

        public void DeleteUser(string username)
        {
            ApplicationUser user = GetUser(username);
            _repository.SoftDelete(user);
            _uow.Commit();
        }
    }
}


