using Jack.Application.AutoMapper;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Jack.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;

            using (var config = new HttpConfiguration())
            {
                config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

                config.Filters.Add(new ElmahExceptionFilter());
            }

        }

    }


    //public class MvcApplication : NinjectHttpApplication
    //{

    //    protected override void OnApplicationStarted()
    //    {
    //        base.OnApplicationStarted();

    //        AreaRegistration.RegisterAllAreas();
    //        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    //        RouteConfig.RegisterRoutes(RouteTable.Routes);
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);
    //        AutoMapperConfig.RegisterMappings();

    //        var config = new HttpConfiguration();
    //        config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    //        config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

    //        config.Filters.Add(new ElmahExceptionFilter());

    //    }

    //    protected override IKernel CreateKernel()
    //    {
    //        var kernel = new StandardKernel();
    //        RegisterServices(kernel);
    //        return kernel;
    //    }

    //    /// <summary>
    //    /// Load your modules or register your services here!
    //    /// </summary>
    //    /// <param name="kernel">The kernel.</param>
    //    private static void RegisterServices(IKernel kernel)
    //    {

    //        #region Iunit
    //        kernel.Bind<IUnityOfWork>().To<UnityOfWork>();
    //        #endregion

    //        #region Calcado
    //        kernel.Bind<ICalcadoServiceApp>().To<CalcadoServiceApp>();
    //        kernel.Bind<ICalcadoService>().To<CalcadoService>();
    //        kernel.Bind<ICalcadoRepository>().To<CalcadoRepository>();
    //        #endregion

    //        #region Colaborador
    //        kernel.Bind<IColaboradorServiceApp>().To<ColaboradorServiceApp>();
    //        kernel.Bind<IColaboradorService>().To<ColaboradorService>();
    //        kernel.Bind<IColaboradorRepository>().To<ColaboradorRepository>();
    //        #endregion

    //        #region Colaborador Crianca
    //        kernel.Bind<IColaboradorCriancaServiceApp>().To<ColaboradorCriancaServiceApp>();
    //        kernel.Bind<IColaboradorCriancaService>().To<ColaboradorCriancaService>();
    //        kernel.Bind<IColaboradorCriancaRepository>().To<ColaboradorCriancaRepository>();
    //        #endregion

    //        #region Crianca
    //        kernel.Bind<ICriancaServiceApp>().To<CriancaServiceApp>();
    //        kernel.Bind<ICriancaService>().To<CriancaService>();
    //        kernel.Bind<ICriancaRepository>().To<CriancaRepository>();
    //        #endregion

    //        #region Familia
    //        kernel.Bind<IFamiliaServiceApp>().To<FamiliaServiceApp>();
    //        kernel.Bind<IFamiliaService>().To<FamiliaService>();
    //        kernel.Bind<IFamiliaRepository>().To<FamiliaRepository>();
    //        #endregion

    //        #region Feriado
    //        kernel.Bind<IFeriadoServiceApp>().To<FeriadoServiceApp>();
    //        kernel.Bind<IFeriadoService>().To<FeriadoService>();
    //        kernel.Bind<IFeriadoRepository>().To<FeriadoRepository>();
    //        #endregion

    //        #region Kit
    //        kernel.Bind<IKitServiceApp>().To<KitServiceApp>();
    //        kernel.Bind<IKitService>().To<KitService>();
    //        kernel.Bind<IKitRepository>().To<KitRepository>();
    //        #endregion

    //        #region Kit Item
    //        kernel.Bind<IKitItemServiceApp>().To<KitItemServiceApp>();
    //        kernel.Bind<IKitItemService>().To<KitItemService>();
    //        kernel.Bind<IKitItemRepository>().To<KitItemRepository>();
    //        #endregion

    //        #region Logs
    //        kernel.Bind<ILogRepository>().To<LogRepository>();
    //        kernel.Bind<ILogSacolasRepository>().To<LogSacolasRepository>();
    //        #endregion

    //        #region Nivel
    //        kernel.Bind<INivelServiceApp>().To<NivelServiceApp>();
    //        kernel.Bind<INivelService>().To<NivelService>();
    //        kernel.Bind<INivelRepository>().To<NivelRepository>();
    //        #endregion

    //        #region Parametro
    //        kernel.Bind<IParametroServiceApp>().To<ParametroServiceApp>();
    //        kernel.Bind<IParametroService>().To<ParametroService>();
    //        kernel.Bind<IParametroRepository>().To<ParametroRepository>();
    //        #endregion

    //        #region Presenca
    //        kernel.Bind<IPresencaServiceApp>().To<PresencaServiceApp>();
    //        kernel.Bind<IPresencaService>().To<PresencaService>();
    //        kernel.Bind<IPresencaRepository>().To<PresencaRepository>();
    //        #endregion

    //        #region Representante
    //        kernel.Bind<IRepresentanteServiceApp>().To<RepresentanteServiceApp>();
    //        kernel.Bind<IRepresentanteService>().To<RepresentanteService>();
    //        kernel.Bind<IRepresentanteRepository>().To<RepresentanteRepository>();
    //        #endregion

    //        #region Reuniao
    //        kernel.Bind<IReuniaoServiceApp>().To<ReuniaoServiceApp>();
    //        kernel.Bind<IReuniaoService>().To<ReuniaoService>();
    //        kernel.Bind<IReuniaoRepository>().To<ReuniaoRepository>();
    //        #endregion

    //        #region Roupa
    //        kernel.Bind<IRoupaServiceApp>().To<RoupaServiceApp>();
    //        kernel.Bind<IRoupaService>().To<RoupaService>();
    //        kernel.Bind<IRoupaRepository>().To<RoupaRepository>();
    //        #endregion

    //        #region Sacola
    //        kernel.Bind<ISacolaServiceApp>().To<SacolaServiceApp>();
    //        kernel.Bind<ISacolaService>().To<SacolaService>();
    //        kernel.Bind<ISacolaRepository>().To<SacolaRepository>();
    //        #endregion

    //        #region Sacola Histórico
    //        kernel.Bind<ISacolaHistoricoServiceApp>().To<SacolaHistoricoServiceApp>();
    //        kernel.Bind<ISacolaHistoricoService>().To<SacolaHistoricoService>();
    //        kernel.Bind<ISacolaHistoricoRepository>().To<SacolaHistoricoRepository>();
    //        #endregion

    //        #region Status Crianca
    //        kernel.Bind<IStatusCriancaServiceApp>().To<StatusCriancaServiceApp>();
    //        kernel.Bind<IStatusCriancaService>().To<StatusCriancaService>();
    //        kernel.Bind<IStatusCriancaRepository>().To<StatusCriancaRepository>();
    //        #endregion

    //        #region Status Familia
    //        kernel.Bind<IStatusFamiliaServiceApp>().To<StatusFamiliaServiceApp>();
    //        kernel.Bind<IStatusFamiliaService>().To<StatusFamiliaService>();
    //        kernel.Bind<IStatusFamiliaRepository>().To<StatusFamiliaRepository>();
    //        #endregion

    //        #region Tipo Item
    //        kernel.Bind<ITipoItemServiceApp>().To<TipoItemServiceApp>();
    //        kernel.Bind<ITipoItemService>().To<TipoItemService>();
    //        kernel.Bind<ITipoItemRepository>().To<TipoItemRepository>();
    //        #endregion

    //        #region Tipo Parentesco
    //        kernel.Bind<ITipoParentescoServiceApp>().To<TipoParentescoServiceApp>();
    //        kernel.Bind<ITipoParentescoService>().To<TipoParentescoService>();
    //        kernel.Bind<ITipoParentescoRepository>().To<TipoParentescoRepository>();
    //        #endregion

    //    }

    //}
}
