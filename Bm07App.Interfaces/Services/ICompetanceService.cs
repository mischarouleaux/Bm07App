using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface ICompetanceService
    {
        Competance GetCompetanceById(int id);
        bool AddCompetance(Competance competance);
        bool EditCompetance(Competance competance);
        IQueryable<Competance> GetAllCompetance();
    }
}
