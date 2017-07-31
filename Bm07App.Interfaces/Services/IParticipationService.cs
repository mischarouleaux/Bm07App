using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface IParticipationService
    {
        Participation GetParticipationById(int id);
        bool AddParticipation(Participation participation);
        bool EditParticipation(Participation participation);
        IQueryable<Participation> GetParticipationFromActivityId(int activityId);
    }
}
