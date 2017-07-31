using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface ISessionTokenService
    {
        string GetSessionToken(ApplicationUser user);

        /// <summary>
        /// Gets an user by its current session token. If the provided session token is not valid, <see cref="ArgumentException"/> is raised.
        /// <para>
        /// Throws <see cref="ArgumentException"/>.
        /// </para>
        /// </summary>
        /// <param name="sessionToken">The session token of the user</param>
        /// <returns></returns>
        ApplicationUser GetUserByToken(string sessionToken);

        /// <summary>
        /// Makes sure the given token is invalid until the user of the token logs in again.
        /// </summary>
        /// <param name="sessionToken">The token to invalidate</param>
        /// <returns></returns>
        bool InvalidateToken(string sessionToken);
    }
}
