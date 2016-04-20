using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Jack.Presentation.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);


            HttpConfiguration config = GlobalConfiguration.Configuration;
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());

            //JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings();
            //jSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jSettings;

            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //var serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            //var contractResolver = (DefaultContractResolver)serializerSettings.ContractResolver;
            //contractResolver.IgnoreSerializableAttribute = true;

            GlobalConfiguration.Configuration.EnsureInitialized();

            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
        }
    }
}