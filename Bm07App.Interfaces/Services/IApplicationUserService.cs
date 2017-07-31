using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface IApplicationUserService
    {
        bool Verify(string username, string token);

        ApplicationUser GetUserByCredentials(string username, string password);

        ApplicationUser GetApplicationUserById(int id);

        IQueryable<ApplicationUser> GetAllUsers();

        void validateUser(int id, bool active);

        bool TryLock(ApplicationUser requestingUser, long accountIToLock);

        bool UpdateUser(ApplicationUser user, string password);
        string[] GetAllUserNames();
        ApplicationUser GetUser(string username);
        void DeleteUser(string username);
    }
}
