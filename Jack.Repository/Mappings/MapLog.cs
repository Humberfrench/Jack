using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapLog : ClassMap<Log>
    {
        public MapLog()
        {
            //Table
            Table("Log");
            LazyLoad();

            //Fields
            Id(x => x.Id).Column("Id");
            Map(x => x.Codigo).Column("Codigo").Not.Nullable();
            Map(x => x.StatusEntidade).Column("StatusEntidade").Not.Nullable();
            Map(x => x.Entidade).Column("Entidade").Not.Nullable();
            Map(x => x.Processo).Column("Processo").Not.Nullable();
            Map(x => x.Mensagem).Column("Mensagem").Not.Nullable();
            Map(x => x.Data).Column("Data").Not.Nullable();

        }
    }
}
