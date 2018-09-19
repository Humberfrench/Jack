
using AutoMapper;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;

namespace Jack.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        //protected override void Configure()
        public ViewModelToDomainMappingProfile()
        {

            Mapper.Initialize(cfg =>
            {
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
        }

    }
}