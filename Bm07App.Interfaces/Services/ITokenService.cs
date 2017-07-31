using Bm07App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm07App.Interfaces.Services
{
    public interface ITokenService
    {
        string GetSessionToken(ApplicationUser user);
    }
}
