using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapSacolaHistorico : ClassMap<SacolaHistorico>
    {
        public MapSacolaHistorico()
        {
            //Table
            Table("SacolasHistorico");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Ano).Column("Ano").Not.Nullable();
            Map(x => x.Sacola).Column(nameof(Sacola)).Not.Nullable();
            Map(x => x.SacolaFamilia).Column("SacolaFamilia").Not.Nullable();
            Map(x => x.Sexo).Column("Sexo").Not.Nullable();
            Map(x => x.Liberado).Column("Liberado").Not.Nullable();

            //References
            References(x => x.Familia).Column(nameof(Familia)).Not.Nullable().Not.LazyLoad();
            References(x => x.FamiliaRepresentante).Column("FamiliaRepresentante").Not.Nullable().Not.LazyLoad();
            References(x => x.Crianca).Column(nameof(Crianca)).Not.Nullable().Not.LazyLoad();
            References(x => x.Kit).Column(nameof(Kit)).Not.Nullable().Not.LazyLoad();
            References(x => x.Nivel).Column(nameof(Nivel)).Not.Nullable().Not.LazyLoad();

        }
    }
}
