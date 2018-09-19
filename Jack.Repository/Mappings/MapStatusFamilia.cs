using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapStatusFamilia : ClassMap<StatusFamilia>
    {
        public MapStatusFamilia()
        {
            //Table
            Table("StatusFamilia");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.PermiteSacola).Column("PermiteSacola").Not.Nullable();
            Map(x => x.ProcessaStatus).Column("ProcessaStatus").Not.Nullable();

            ////References
            HasMany(x => x.Familias).KeyColumn("Status").Inverse().Not.LazyLoad();
        }
    }
}
