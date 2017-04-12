using GastosBack_ConsoleApp.Resolver;
using Microsoft.Practices.Unity;
using Owin;
using SelfHostedWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Swashbuckle.Application;

namespace SelfHostedWebApi
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Swashbuckle
            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "Self Hosted WebApi"))
                .EnableSwaggerUi();

            //Unity
            var container = new UnityContainer();
            container.RegisterType<IProvinceRepo, ProvinceRepo>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            //Json
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            appBuilder.UseWebApi(config);
        }
    }
}
