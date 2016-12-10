
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

        protected override void Configure()
        {

            Mapper.CreateMap<CalcadoViewModel, Calcado>();
            Mapper.CreateMap<ColaboradorViewModel, Colaborador>();
            Mapper.CreateMap<ColaboradorCriancaViewModel, ColaboradorCrianca>();
            Mapper.CreateMap<CriancaValueViewModel, CriancaValue>();
            Mapper.CreateMap<CriancaVestimentaViewModel, CriancaVestimenta>();
            Mapper.CreateMap<CriancaViewModel, Crianca>();
            Mapper.CreateMap<FamiliaViewModel, Familia>();
            Mapper.CreateMap<FeriadoViewModel, Feriado>();
            Mapper.CreateMap<KitViewModel, Kit>();
            Mapper.CreateMap<KitItemViewModel, KitItem>();
            Mapper.CreateMap<NivelViewModel, Nivel>();
            Mapper.CreateMap<ParametroViewModel, Parametro>();
            Mapper.CreateMap<PresencaViewModel, Presenca>();
            Mapper.CreateMap<RepresentanteViewModel, Representante>();
            Mapper.CreateMap<ReuniaoViewModel, Reuniao>();
            Mapper.CreateMap<RoupaViewModel, Roupa>();
            Mapper.CreateMap<SacolaViewModel, Sacola>();
            Mapper.CreateMap<StatsViewModel, Stats>();
            Mapper.CreateMap<StatusFamiliaViewModel, StatusFamilia>();
            Mapper.CreateMap<StatusCriancaViewModel, StatusCrianca>();
            Mapper.CreateMap<TipoItemViewModel, TipoItem>();

        }
    }
}