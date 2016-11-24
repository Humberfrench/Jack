using AutoMapper;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;

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
            Mapper.CreateMap<Calcado, CalcadoViewModel>();
            Mapper.CreateMap<Colaborador, ColaboradorViewModel>();
            Mapper.CreateMap<ColaboradorCrianca, ColaboradorCriancaViewModel>();
            Mapper.CreateMap<Crianca, CriancaViewModel>();
            Mapper.CreateMap<Familia, FamiliaViewModel>();
            Mapper.CreateMap<Feriado, FeriadoViewModel>();
            Mapper.CreateMap<Kit, KitViewModel>();
            Mapper.CreateMap<KitItem, KitItemViewModel>();
            Mapper.CreateMap<Nivel, NivelViewModel>();
            Mapper.CreateMap<Presenca, PresencaViewModel>();
            Mapper.CreateMap<Representante, RepresentanteViewModel>();
            Mapper.CreateMap<Reuniao, ReuniaoViewModel>();
            Mapper.CreateMap<Roupa, RoupaViewModel>();
            Mapper.CreateMap<Sacola, SacolaViewModel>();
            Mapper.CreateMap<StatusFamilia, StatusFamiliaViewModel>();
            Mapper.CreateMap<StatusCrianca, StatusCriancaViewModel>();
            Mapper.CreateMap<TipoItem, TipoItemViewModel>();

        }
    }
}