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

        protected override void Configure()
        {
            Mapper.CreateMap<Calcado, CalcadoViewModel>().MaxDepth(2);
            Mapper.CreateMap<Colaborador, ColaboradorViewModel>().MaxDepth(2);
            Mapper.CreateMap<ColaboradorCrianca, ColaboradorCriancaViewModel>().MaxDepth(2);
            Mapper.CreateMap<Crianca, CriancaViewModel>().MaxDepth(2);
            Mapper.CreateMap<CriancaValue, CriancaValueViewModel>().MaxDepth(2);
            Mapper.CreateMap<CriancaVestimenta, CriancaVestimentaViewModel>().MaxDepth(2);
            Mapper.CreateMap<Familia, FamiliaViewModel>().MaxDepth(2);
            Mapper.CreateMap<Feriado, FeriadoViewModel>().MaxDepth(2);
            Mapper.CreateMap<Kit, KitViewModel>().MaxDepth(2);
            Mapper.CreateMap<KitItem, KitItemViewModel>().MaxDepth(2);
            Mapper.CreateMap<Nivel, NivelViewModel>().MaxDepth(2);
            Mapper.CreateMap<Parametro, ParametroViewModel>().MaxDepth(2);
            Mapper.CreateMap<Presenca, PresencaViewModel>().MaxDepth(2);
            Mapper.CreateMap<Representante, RepresentanteViewModel>().MaxDepth(2);
            Mapper.CreateMap<Reuniao, ReuniaoViewModel>().MaxDepth(2);
            Mapper.CreateMap<Roupa, RoupaViewModel>().MaxDepth(2);
            Mapper.CreateMap<Sacola, SacolaViewModel>().MaxDepth(2);
            Mapper.CreateMap<Stats, StatsViewModel>().MaxDepth(2);
            Mapper.CreateMap<StatusFamilia, StatusFamiliaViewModel>().MaxDepth(2);
            Mapper.CreateMap<StatusCrianca, StatusCriancaViewModel>().MaxDepth(2);
            Mapper.CreateMap<TipoItem, TipoItemViewModel>().MaxDepth(2);
            Mapper.CreateMap<TipoParentesco, TipoParentescoViewModel>().MaxDepth(2);

        }
    }
}