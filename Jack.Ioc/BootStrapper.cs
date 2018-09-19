using Jack.Application;
using Jack.Application.Interfaces;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.Services;
using Jack.Repository;
using Jack.Repository.UnityOfWork;
using SimpleInjector;

namespace Jack.Ioc
{
    public class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            MyContainer = container;

            #region Iunit
            container.Register<IUnityOfWork, UnityOfWork>(Lifestyle.Scoped);
            #endregion

            #region Calcado
            container.Register<ICalcadoServiceApp, CalcadoServiceApp>(Lifestyle.Scoped);
            container.Register<ICalcadoService, CalcadoService>(Lifestyle.Scoped);
            container.Register<ICalcadoRepository, CalcadoRepository>(Lifestyle.Scoped);
            #endregion

            #region Colaborador
            container.Register<IColaboradorServiceApp, ColaboradorServiceApp>(Lifestyle.Scoped);
            container.Register<IColaboradorService, ColaboradorService>(Lifestyle.Scoped);
            container.Register<IColaboradorRepository, ColaboradorRepository>(Lifestyle.Scoped);
            #endregion

            #region Colaborador Crianca
            container.Register<IColaboradorCriancaServiceApp, ColaboradorCriancaServiceApp>(Lifestyle.Scoped);
            container.Register<IColaboradorCriancaService, ColaboradorCriancaService>(Lifestyle.Scoped);
            container.Register<IColaboradorCriancaRepository, ColaboradorCriancaRepository>(Lifestyle.Scoped);
            #endregion

            #region Crianca
            container.Register<ICriancaServiceApp, CriancaServiceApp>(Lifestyle.Scoped);
            container.Register<ICriancaService, CriancaService>(Lifestyle.Scoped);
            container.Register<ICriancaRepository, CriancaRepository>(Lifestyle.Scoped);
            #endregion

            #region Familia
            container.Register<IFamiliaServiceApp, FamiliaServiceApp>(Lifestyle.Scoped);
            container.Register<IFamiliaService, FamiliaService>(Lifestyle.Scoped);
            container.Register<IFamiliaRepository, FamiliaRepository>(Lifestyle.Scoped);
            #endregion

            #region Feriado
            container.Register<IFeriadoServiceApp, FeriadoServiceApp>(Lifestyle.Scoped);
            container.Register<IFeriadoService, FeriadoService>(Lifestyle.Scoped);
            container.Register<IFeriadoRepository, FeriadoRepository>(Lifestyle.Scoped);
            #endregion

            #region Kit
            container.Register<IKitServiceApp, KitServiceApp>(Lifestyle.Scoped);
            container.Register<IKitService, KitService>(Lifestyle.Scoped);
            container.Register<IKitRepository, KitRepository>(Lifestyle.Scoped);
            #endregion

            #region Kit Item
            container.Register<IKitItemServiceApp, KitItemServiceApp>(Lifestyle.Scoped);
            container.Register<IKitItemService, KitItemService>(Lifestyle.Scoped);
            container.Register<IKitItemRepository, KitItemRepository>(Lifestyle.Scoped);
            #endregion

            #region Logs
            container.Register<ILogRepository, LogRepository>(Lifestyle.Scoped);
            container.Register<ILogSacolasRepository, LogSacolasRepository>(Lifestyle.Scoped);
            #endregion

            #region Nivel
            container.Register<INivelServiceApp, NivelServiceApp>(Lifestyle.Scoped);
            container.Register<INivelService, NivelService>(Lifestyle.Scoped);
            container.Register<INivelRepository, NivelRepository>(Lifestyle.Scoped);
            #endregion

            #region Parametro
            container.Register<IParametroServiceApp, ParametroServiceApp>(Lifestyle.Scoped);
            container.Register<IParametroService, ParametroService>(Lifestyle.Scoped);
            container.Register<IParametroRepository, ParametroRepository>(Lifestyle.Scoped);
            #endregion

            #region Presenca
            container.Register<IPresencaServiceApp, PresencaServiceApp>(Lifestyle.Scoped);
            container.Register<IPresencaService, PresencaService>(Lifestyle.Scoped);
            container.Register<IPresencaRepository, PresencaRepository>(Lifestyle.Scoped);
            #endregion

            #region Representante
            container.Register<IRepresentanteServiceApp, RepresentanteServiceApp>(Lifestyle.Scoped);
            container.Register<IRepresentanteService, RepresentanteService>(Lifestyle.Scoped);
            container.Register<IRepresentanteRepository, RepresentanteRepository>(Lifestyle.Scoped);
            #endregion

            #region Reuniao
            container.Register<IReuniaoServiceApp, ReuniaoServiceApp>(Lifestyle.Scoped);
            container.Register<IReuniaoService, ReuniaoService>(Lifestyle.Scoped);
            container.Register<IReuniaoRepository, ReuniaoRepository>(Lifestyle.Scoped);
            #endregion

            #region Roupa
            container.Register<IRoupaServiceApp, RoupaServiceApp>(Lifestyle.Scoped);
            container.Register<IRoupaService, RoupaService>(Lifestyle.Scoped);
            container.Register<IRoupaRepository, RoupaRepository>(Lifestyle.Scoped);
            #endregion

            #region Sacola
            container.Register<ISacolaServiceApp, SacolaServiceApp>(Lifestyle.Scoped);
            container.Register<ISacolaService, SacolaService>(Lifestyle.Scoped);
            container.Register<ISacolaRepository, SacolaRepository>(Lifestyle.Scoped);
            #endregion

            #region Sacola Histórico
            container.Register<ISacolaHistoricoServiceApp, SacolaHistoricoServiceApp>(Lifestyle.Scoped);
            container.Register<ISacolaHistoricoService, SacolaHistoricoService>(Lifestyle.Scoped);
            container.Register<ISacolaHistoricoRepository, SacolaHistoricoRepository>(Lifestyle.Scoped);
            #endregion

            #region Status Crianca
            container.Register<IStatusCriancaServiceApp, StatusCriancaServiceApp>(Lifestyle.Scoped);
            container.Register<IStatusCriancaService, StatusCriancaService>(Lifestyle.Scoped);
            container.Register<IStatusCriancaRepository, StatusCriancaRepository>(Lifestyle.Scoped);
            #endregion

            #region Status Familia
            container.Register<IStatusFamiliaServiceApp, StatusFamiliaServiceApp>(Lifestyle.Scoped);
            container.Register<IStatusFamiliaService, StatusFamiliaService>(Lifestyle.Scoped);
            container.Register<IStatusFamiliaRepository, StatusFamiliaRepository>(Lifestyle.Scoped);
            #endregion

            #region Status Tratamento
            container.Register<IStatusTratamentoServiceApp, StatusTratamentoServiceApp>(Lifestyle.Scoped);
            container.Register<IStatusTratamentoService, StatusTratamentoService>(Lifestyle.Scoped);
            container.Register<IStatusTratamentoRepository, StatusTratamentoRepository>(Lifestyle.Scoped);
            #endregion

            #region Tratamento
            container.Register<ITratamentoServiceApp, TratamentoServiceApp>(Lifestyle.Scoped);
            container.Register<ITratamentoService, TratamentoService>(Lifestyle.Scoped);
            container.Register<ITratamentoRepository, TratamentoRepository>(Lifestyle.Scoped);
            #endregion


            #region Tratamento
            container.Register<ITratamentoTiposDeProblemaServiceApp, TratamentoTiposDeProblemaServiceApp>(Lifestyle.Scoped);
            container.Register<ITratamentoTiposDeProblemaService, TratamentoTiposDeProblemaService>(Lifestyle.Scoped);
            container.Register<ITratamentoTiposDeProblemaRepository, TratamentoTiposDeProblemaRepository>(Lifestyle.Scoped);
            #endregion
            #region Tipo Item
            container.Register<ITipoItemServiceApp, TipoItemServiceApp>(Lifestyle.Scoped);
            container.Register<ITipoItemService, TipoItemService>(Lifestyle.Scoped);
            container.Register<ITipoItemRepository, TipoItemRepository>(Lifestyle.Scoped);
            #endregion

            #region Tipo Parentesco
            container.Register<ITipoParentescoServiceApp, TipoParentescoServiceApp>(Lifestyle.Scoped);
            container.Register<ITipoParentescoService, TipoParentescoService>(Lifestyle.Scoped);
            container.Register<ITipoParentescoRepository, TipoParentescoRepository>(Lifestyle.Scoped);
            #endregion


            #region Tipo Problema
            container.Register<ITipoDeProblemaServiceApp, TipoDeProblemaServiceApp>(Lifestyle.Scoped);
            container.Register<ITipoDeProblemaService, TipoDeProblemaService>(Lifestyle.Scoped);
            container.Register<ITipoDeProblemaRepository, TipoDeProblemaRepository>(Lifestyle.Scoped);
            #endregion

        }

    }
}
