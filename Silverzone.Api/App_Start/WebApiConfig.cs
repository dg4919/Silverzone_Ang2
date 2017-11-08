using System.Web.Http;
using System.Web.Http.Cors;

namespace Silverzone.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // enable cors to call this api by jquery/angularjs
            var cors = new EnableCorsAttribute("*", "*", "*");      // allow from all origins > means from which url this API will call
            config.EnableCors(cors);

            // enable attribute based routes for Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "VersoningAPI",
                routeTemplate: "api/{namespace}/{controller}/{action}/{Id}",
                defaults: new { Id = RouteParameter.Optional }
            );


            // to enable Json return type > while accessing API from browser
            //var formatter = GlobalConfiguration.Configuration.Formatters;
            //formatter.Remove(formatter.XmlFormatter);

            //formatter.JsonFormatter.SerializerSettings.ContractResolver =
            //    new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

        }
    }
}
