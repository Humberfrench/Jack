using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapFeriado : ClassMap<Feriado>
    {
        public MapFeriado()
        {
            //Table
            Table("Feriado");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Nome).Column("Nome").Not.Nullable();
            Map(x => x.Data).Column("Data").Not.Nullable();
            Map(x => x.AnoEfetivo).Column("AnoEfetivo").Not.Nullable();
            Map(x => x.ReuniaoAnterior).Column("ReuniaoAnterior").Not.Nullable();
            Map(x => x.ProximaReuniao).Column("ProximaReuniao").Not.Nullable();
            Map(x => x.PodeTerReuniao).Column("PodeTerReuniao").Not.Nullable();

        }
    }
}
