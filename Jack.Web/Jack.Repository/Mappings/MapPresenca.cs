using FluentNHibernate.Mapping;
using System;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapPresenca : ClassMap<Presenca>
    {
        public MapPresenca()
        {
            //Table
            Table("Presenca");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");

            //References
            References(x => x.Familia).Column("Familia").Not.Nullable().Not.LazyLoad();
            References(x => x.Reuniao).Column("Reuniao").Not.Nullable().Not.LazyLoad();

        }
    }
}
