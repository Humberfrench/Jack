using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    public class MapTratamentoTiposDeProblema : ClassMap<TratamentoTipoDeProblema>
    {
        public MapTratamentoTiposDeProblema()
        {
            Table(nameof(TratamentoTipoDeProblema));
            LazyLoad();
            Id(x => x.TratamentoTipoDeProblemaId).GeneratedBy.Identity().Column("TratamentoTipoDeProblemaId");
            References(x => x.TiposDeProblema).Column("TiposDeProblemaId");
            References(x => x.Tratamento).Column("TratamentoId");
        }
    }
}