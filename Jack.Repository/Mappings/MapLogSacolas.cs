using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapLogSacolas : ClassMap<LogSacolas>
    {
        public MapLogSacolas()
        {
            //Table
            Table("LogSacolas");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Familia).Column("Familia").Not.Nullable();
            Map(x => x.FamiliaRepresentante).Column("FamiliaRepresentante").Not.Nullable();
            Map(x => x.Crianca).Column("Crianca").Not.Nullable();
            Map(x => x.Kit).Column("Kit").Not.Nullable();
            Map(x => x.Ano).Column("Ano").Not.Nullable();

        }
    }
}
