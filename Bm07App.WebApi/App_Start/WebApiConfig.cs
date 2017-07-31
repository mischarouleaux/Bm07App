using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Bm07App.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Let's just use JSON. K thnx bye?
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Use camel casing without changing our server-side data model:
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Ignoring circular reference for JSON serialization
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Add a filter to enable users to get an unpretty version of the JSON.
            // Specify the unpretty paramater using either ?unpretty or ?unpretty=true.
            // config.Filters.Add(new UnprettyPrintFilterAttribute());

            // Always use HTTPS for our endpoints. That's way safer.
#if !DEBUG
            // Commented by Marc to get things working for a first Azure push!    
            // config.Filters.Add(new ExpenseClaim.Api.Attributes.ForceHttpsAttribute());
#endif

            // We must receive a user agent for a request to work.
            //config.Filters.Add(new ForceUserAgentAttribute()); TODO

            // Add a method override handler for PUT and DELETE.
            // GlobalConfiguration.Configuration.MessageHandlers.Add(new MethodOverrideHandler()); TODO

            // Add support for compression using these message handlers.
            // This is using a NuGet package called Microsoft.AspNet.WebApi.MessageHandlers.Compression.
            //GlobalConfiguration.Configuration.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor())); TODO

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
