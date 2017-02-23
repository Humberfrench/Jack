using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapStatusCrianca : ClassMap<StatusCrianca>
    {
        public MapStatusCrianca()
        {
            //Table
            Table("StatusCrianca");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.PermiteSacola).Column("PermiteSacola").Not.Nullable();

            ////References
            HasMany(x => x.Criancas).KeyColumn("Status").Inverse().Not.LazyLoad();
        }
    }
}
