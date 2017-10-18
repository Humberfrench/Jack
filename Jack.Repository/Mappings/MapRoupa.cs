using FluentNHibernate.Mapping;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapRoupa : ClassMap<Roupa>
    {
        public MapRoupa()
        {
            //Table
            Table(nameof(Roupa));
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.Tamanho).Column("TamanhoSugerido").Not.Nullable();
            Map(x => x.TamanhoMaior).Column("TamanhoSugeridoMaior").Not.Nullable();
            Map(x => x.Idade).Column("Idade").Not.Nullable();
            Map(x => x.MedidaIdade).Column("MedidaIdade").Nullable();


        }
    }
}
