using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface IICFService
    {
        List<ICF> GetAllICF();
        ICF GetICF(long id);
        void AddICF(ICF icf);
        void EditICF(ICF icf);
    }
}
