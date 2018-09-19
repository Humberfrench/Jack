using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    public class MapTipoDeProblema : ClassMap<TipoDeProblema>
    {

        public MapTipoDeProblema()
        {
            Table("TiposDeProblema");
            LazyLoad();
            Id(x => x.TipoDeProblemaId).GeneratedBy.Identity().Column("TipoDeProblemaId");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            HasMany(x => x.TratamentoTipoDeProblema).KeyColumn("TipoDeProblemaId");
        }
    }
}