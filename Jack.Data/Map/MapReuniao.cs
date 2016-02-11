using FluentNHibernate.Mapping;
using System;


namespace Jack.Data.Map
{
    class MapReuniao : ClassMap<Model.Reuniao>
    {
        public MapReuniao()
        {
            //Table
            Table("tb_reuniao_agendada");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Ano).Column("nr_ano").Not.Nullable();
            Map(x => x.AnoCorrente).Column("nr_ano_efetivo").Not.Nullable();
            Map(x => x.Data).Column("dt_reuniao").Not.Nullable();

            //References
            References(x => x.Familia).Column("id_familia").Not.Nullable();

            //Hasmany
            HasMany(x => x.Familia).Cascade.AllDeleteOrphan()
                                   .Fetch.Join()
                                   .Inverse().KeyColumn("id_familia");

        }
    }
}
