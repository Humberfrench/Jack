using FluentNHibernate.Mapping;
using System;


namespace Jack.Data.Map
{
    class MapPresenca : ClassMap<Model.Presenca>
    {
        public MapPresenca()
        {
            //Table
            Table("tb_familia_presenca");
            
            //Fields
            Id(x => x.Codigo);

            //References
            References(x => x.Familia).Column("id_familia").Not.Nullable();
            References(x => x.Reuniao).Column("id_reuniao").Not.Nullable();

        }
    }
}
