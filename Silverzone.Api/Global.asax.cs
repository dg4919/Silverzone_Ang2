using Autofac;
using Autofac.Integration.WebApi;
using Silverzone.Api.Modules;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;

namespace Silverzone.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //  **************  WEB API Actions  **************

            GlobalConfiguration.Configure(WebApiConfig.Register);        // reigster WEB Api 2

            // register service to use API versioning on behalf of namespace
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector),
            new WebApiNamespaceVersoning(GlobalConfiguration.Configuration));

            // handling error globally
            GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger),
                new GlobalExceptionHandler());

            // dependency injection using autofac
            autofacDependency_Resolver();

            //  ****************************
        }

        private void autofacDependency_Resolver()
        {
            //adding mapping
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();      // Register WebApi Controllers

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new EFModule());

            var container = builder.Build();

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));       // Set the MVC DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);  // Set the WebApi DependencyResolver
        }

    }
}
