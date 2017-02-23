using FluentNHibernate.Mapping;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapTipoItem : ClassMap<TipoItem>
    {
        public MapTipoItem()
        {
            //Table
            Table("TipoItem");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.Opcional).Column("Opcional").Not.Nullable();

        }
    }
}
