using AutoMapper;
using Jack.Application.AutoMapper;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;


namespace Jack.Application.AutoMapper
{                      
    public class AutoMapperConfig
    {
        public static MapperConfiguration Config;
        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Calcado, CalcadoViewModel>().MaxDepth(2);
                cfg.CreateMap<Colaborador, ColaboradorViewModel>().MaxDepth(2);
                cfg.CreateMap<ColaboradorCrianca, ColaboradorCriancaViewModel>().MaxDepth(2);
                cfg.CreateMap<Crianca, CriancaViewModel>().MaxDepth(2);
                cfg.CreateMap<CriancaValue, CriancaValueViewModel>().MaxDepth(2);
                cfg.CreateMap<CriancaVestimenta, CriancaVestimentaViewModel>().MaxDepth(2);
                cfg.CreateMap<Familia, FamiliaViewModel>().MaxDepth(2);
                cfg.CreateMap<Feriado, FeriadoViewModel>().MaxDepth(2);
                cfg.CreateMap<Kit, KitViewModel>().MaxDepth(2);
                cfg.CreateMap<KitItem, KitItemViewModel>().MaxDepth(2);
                cfg.CreateMap<Nivel, NivelViewModel>().MaxDepth(2);
                cfg.CreateMap<Parametro, ParametroViewModel>().MaxDepth(2);
                cfg.CreateMap<Presenca, PresencaViewModel>().MaxDepth(2);
                cfg.CreateMap<Representante, RepresentanteViewModel>().MaxDepth(2);
                cfg.CreateMap<Reuniao, ReuniaoViewModel>().MaxDepth(2);
                cfg.CreateMap<Roupa, RoupaViewModel>().MaxDepth(2);
                cfg.CreateMap<Sacola, SacolaViewModel>().MaxDepth(2);
                cfg.CreateMap<Stats, StatsViewModel>().MaxDepth(2);
                cfg.CreateMap<StatusFamilia, StatusFamiliaViewModel>().MaxDepth(2);
                cfg.CreateMap<StatusCrianca, StatusCriancaViewModel>().MaxDepth(2);
                cfg.CreateMap<TipoItem, TipoItemViewModel>().MaxDepth(2);
                cfg.CreateMap<TipoParentesco, TipoParentescoViewModel>().MaxDepth(2);
                cfg.CreateMap<CalcadoViewModel, Calcado>();
                cfg.CreateMap<ColaboradorViewModel, Colaborador>();
                cfg.CreateMap<ColaboradorCriancaViewModel, ColaboradorCrianca>();
                cfg.CreateMap<CriancaValueViewModel, CriancaValue>();
                cfg.CreateMap<CriancaVestimentaViewModel, CriancaVestimenta>();
                cfg.CreateMap<CriancaViewModel, Crianca>();
                cfg.CreateMap<FamiliaViewModel, Familia>();
                cfg.CreateMap<FeriadoViewModel, Feriado>();
                cfg.CreateMap<KitViewModel, Kit>();
                cfg.CreateMap<KitItemViewModel, KitItem>();
                cfg.CreateMap<NivelViewModel, Nivel>();
                cfg.CreateMap<ParametroViewModel, Parametro>();
                cfg.CreateMap<PresencaViewModel, Presenca>();
                cfg.CreateMap<RepresentanteViewModel, Representante>();
                cfg.CreateMap<ReuniaoViewModel, Reuniao>();
                cfg.CreateMap<RoupaViewModel, Roupa>();
                cfg.CreateMap<SacolaViewModel, Sacola>();
                cfg.CreateMap<StatsViewModel, Stats>();
                cfg.CreateMap<StatusFamiliaViewModel, StatusFamilia>();
                cfg.CreateMap<StatusCriancaViewModel, StatusCrianca>();
                cfg.CreateMap<TipoItemViewModel, TipoItem>();
                cfg.CreateMap<TipoParentescoViewModel, TipoParentesco>();
            });

            Config.AssertConfigurationIsValid();
        }

    }
}