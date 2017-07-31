using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using System.Data.Entity;
using Bm07App.Interfaces.Repositories;
using Bm07App.EF.Repositories;
using Bm07App.EF;
using Bm07App.Interfaces;

namespace Bm07App.DependencyResolution
{
    public class InfrastructureModule
    {
        public void Load(UnityContainer container)
        {
            
            //Register all the repositories
            container.RegisterType<IApplicationUserClientRepository, ApplicationUserClientRepository>();
            container.RegisterType<IApplicationUserGroupRepository, ApplicationUserGroupRepository>();
            container.RegisterType<IApplicationUserRepository, ApplicationUserRepository>();
            container.RegisterType<ICaseRepository, CaseRepository>();            
            container.RegisterType<IClientNoteRepository, ClientNoteRepository>();
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<ICompetanceRepository, CompetanceRepository>();
            container.RegisterType<IEmailTokenRepository, EmailTokenRepository>();
            container.RegisterType<IICFRepository, ICFRepository>();
            container.RegisterType<IActivityRepository, ActivityRepository>();
            container.RegisterType<IMedicalFieldRepository, MedicalFieldRepository>();
            container.RegisterType<IObservationRepository, ObservationRepository>();
            container.RegisterType<IObservationRowRepository, ObservationRowRepository>();
            container.RegisterType<IParticipationRepository, ParticipationRepository>();
            container.RegisterType<ISessionTokenRepository, SessionTokenRepository>();
            container.RegisterType<IUserGroupRepository, UserGroupRepository>();

            

            //Register the DbContext, one instance per lifetime
            container.RegisterType<DbContext, CasusBM07Context>(new PerResolveLifetimeManager(), new InjectionConstructor("CasusBM07Context"));

            //Register the UnitOfWork            
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            

            
        }
      
       
    }
}
