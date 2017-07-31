using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface ICaseService
    {
        Case GetCaseById(int id);
        bool AddCase(Case obsCase);
        bool EditCase(Case obsCase);
        IQueryable<Case> GetFromCompetanceId(int competanceId);
    }
}
