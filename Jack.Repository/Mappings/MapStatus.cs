using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapStatus : ClassMap<Status>
    {
        public MapStatus()
        {
            //Table
            Table("Status");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.PermiteSacola).Column("PermiteSacola").Not.Nullable();
            Map(x => x.TipoStatus).Column("TipoStatus").Not.Nullable();

            ////References
            HasMany(x => x.Criancas).KeyColumn("Status").Inverse().Not.LazyLoad();
            HasMany(x => x.Familias).KeyColumn("Status").Inverse().Not.LazyLoad();
        }
    }
}
