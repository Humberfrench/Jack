using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    public class MapStatusTratamento : ClassMap<StatusTratamento>
    {

        public MapStatusTratamento()
        {
            Table("StatusTratamento");
            LazyLoad();
            Id(x => x.StatusTratamentoId).GeneratedBy.Identity().Column("StatusTratamentoId");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            HasMany(x => x.Tratamento).KeyColumn("StatusTratamentoId");
        }
    }
}
