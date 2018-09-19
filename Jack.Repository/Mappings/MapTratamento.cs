using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    public class MapTratamento : ClassMap<Tratamento>
    {
        public MapTratamento()
        {
            Table("Tratamento");
            LazyLoad();
            Id(x => x.TratamentoId).GeneratedBy.Identity().Column("TratamentoId");
            References(x => x.Familia).Column("FamiliaId");
            References(x => x.StatusTratamento).Column("StatusTratamentoId");
            Map(x => x.DescricaoProblema).Column("DescricaoProblema").Not.Nullable();
            Map(x => x.FeedBackTratamento).Column("FeedBackTratamento");
            Map(x => x.DataInicio).Column("DataInicio");
            Map(x => x.DataFim).Column("DataFim");
            Map(x => x.DataCadastro).Column("DataCadastro").Not.Nullable();
            Map(x => x.DataAtualizacao).Column("DataAtualizacao").Not.Nullable();
            HasMany(x => x.TratamentoTiposDeProblema).KeyColumn("TratamentoId");
        }
    }
}