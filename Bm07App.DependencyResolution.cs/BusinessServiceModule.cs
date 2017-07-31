using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.WebApi;
using Unity;
using Microsoft.Practices.Unity;
using Bm07App.Business.Services;
using Bm07App.Interfaces.Services;


namespace Bm07App.DependencyResolution
{
   public class BusinessServiceModule
    {
        //Register all the components between Business.Services and Interfaces.Service
        public void Load(UnityContainer container)
        {
            container.RegisterType<IActivityService, ActivityService>();
            container.RegisterType<IApplicationUserClientService, ApplicationUserClientService>();
            container.RegisterType<IApplicationUserGroupService, ApplicationUserGroupService>();
            container.RegisterType<IApplicationUserService, ApplicationUserService>();
            container.RegisterType<ICaseService, CaseService>();            
            container.RegisterType<IClientNoteService, ClientNoteService>();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<ICompetanceService, CompetanceService>();
            container.RegisterType<IEmailTokenService, EmailTokenService>();
            container.RegisterType<IICFService, ICFService>();            
            container.RegisterType<IMedicalFieldService, MedicalFieldService>();
            container.RegisterType<IObservationService, ObservationService>();
            container.RegisterType<IObservationRowService, ObservationRowService>();
            container.RegisterType<IParticipationService, ParticipationService>();
            container.RegisterType<ISessionTokenService, SessionTokenService>();
            container.RegisterType<IUserGroupService, UserGroupService>();
        }
    }
}
