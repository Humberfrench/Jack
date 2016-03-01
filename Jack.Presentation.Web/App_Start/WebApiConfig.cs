using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Jack.Presentation.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(name: "ObtemVazios1", routeTemplate: "api/{controller}/Get/{action}/{id}", defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(name: "ObtemVazios2", routeTemplate: "api/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(name: "ActionApiGetFilter", routeTemplate: "api/{controller}/{ID}/{Letter}", defaults: new { ID = RouteParameter.Optional, Letter = RouteParameter.Optional } );

            //config.Routes.MapHttpRoute(
            //    name:="ActionApi2",
            //    routeTemplate:="api/{controller}/{MasterID}/{DetailID}",
            //    defaults:=New With {.MasterID = RouteParameter.Optional, .DetailID = RouteParameter.Optional}
            //)

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            ////config.Formatters.JsonFormatter.
            ////tentativa aqui
            ////https://www.google.com.br/search?q=k__BackingField&oq=k__BackingField&aqs=chrome..69i57&sourceid=chrome&ie=UTF-8#q=k__backingfield+web+api
            //var oResolvercontract = (DefaultContractResolver) config.Formatters.JsonFormatter.SerializerSettings.ContractResolver ;
            //oResolvercontract.IgnoreSerializableAttribute = true;
            //config.Formatters.JsonFormatter.

        }
    }
}
