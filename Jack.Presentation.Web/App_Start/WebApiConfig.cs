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

            //config.Routes.MapHttpRoute(
            //    name:="ActionApi2",
            //    routeTemplate:="api/{controller}/{MasterID}/{DetailID}",
            //    defaults:=New With {.MasterID = RouteParameter.Optional, .DetailID = RouteParameter.Optional}
            //)

            //config.Routes.MapHttpRoute(
            //    name:="ActionApi2",
            //    routeTemplate:="api/{controller}/{MasterID}/{DetailID}",
            //    defaults:=New With {.MasterID = RouteParameter.Optional, .DetailID = RouteParameter.Optional}
            //)

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;

        }
    }
}
