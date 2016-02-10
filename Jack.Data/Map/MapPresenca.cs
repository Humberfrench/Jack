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

            //HasManyToMany
            HasMany<Model.Presenca>(x => x.Familia).Cascade.All().Table("tb_familia");
            HasMany<Model.Presenca>(x => x.Reuniao).Cascade.All().Table("tb_reuniao_agendada");

        }
    }
}
