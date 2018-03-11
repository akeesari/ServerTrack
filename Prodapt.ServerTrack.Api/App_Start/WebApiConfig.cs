using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Prodapt.ServerTrack.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Add Api Versioning constraint resolver 
            //var constraintResolver = new DefaultInlineConstraintResolver()
            //{
            //    ConstraintMap =
            //    {
            //        ["apiVersion"] = typeof(ApiVersionRouteConstraint)
            //    }
            //};

            // Web API routes with versioning goodness
            //config.MapHttpAttributeRoutes(constraintResolver);

            // Enable API Versioning
            //config.AddApiVersioning(o => o.ReportApiVersions = true);

            //EnableCors(config);
            //ConfigureJson(config);

        }
        private static void ConfigureJson(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            json.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            var jsonStyleFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonStyleFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
        private static void EnableCors(HttpConfiguration config)
        {
            //enabling CORS globally
            var cors = new EnableCorsAttribute(
            origins: "*",
            headers: "*",
            methods: "*");
            config.EnableCors(cors);
        }
       
    }
}
