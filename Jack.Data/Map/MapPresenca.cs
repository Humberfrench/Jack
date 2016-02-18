﻿using FluentNHibernate.Mapping;

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

            HasMany(x => x.Reunioes).KeyColumn("id_reuniao");
            HasMany(x => x.Familias).KeyColumn("id_familia");


        }
    }
}
