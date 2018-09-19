using AutoMapper;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;

namespace Jack.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        //protected override void Configure()
        public DomainToViewModelMappingProfile()
        {
            Mapper.Initialize(cfg =>
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
            });
        }
    }
}