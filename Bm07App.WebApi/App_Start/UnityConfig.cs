using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using System.Data.Entity;
using Bm07App.Interfaces.Services;
using Bm07App.Interfaces.Repositories;
using Bm07App.Interfaces;
using Bm07App.DependencyResolution;




namespace Bm07App.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            BusinessServiceModule _BusinessServiceModule = new BusinessServiceModule();
            InfrastructureModule _InfrastructureModule = new InfrastructureModule();

			var container = new UnityContainer();

            // register all your components with the container here
            
            _InfrastructureModule.Load(container);
            _BusinessServiceModule.Load(container);
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}