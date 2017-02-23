using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapKitItem : ClassMap<KitItem>
    {
        public MapKitItem()
        {
            //Table
            Table("KitItem");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Observacao).Column("Observacao").Nullable();
            Map(x => x.Ordem).Column("Ordem").Not.Nullable();

            //References
            References(x => x.Kit).Column("Kit");
            References(x => x.TipoItem).Column("TipoItem");

            //Has Many

        }
    }
}
