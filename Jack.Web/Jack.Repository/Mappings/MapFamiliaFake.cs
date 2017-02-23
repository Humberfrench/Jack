using FluentNHibernate.Mapping;
using System;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapFamiliaFake : ClassMap<FamiliaFake>
    {
        public MapFamiliaFake()
        {
            //Table
            Table("FamiliaFake");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Ativo).Column("Ativo").Not.Nullable();

            //References
            References(x => x.Familia).Column("Familia").Not.Nullable();




        }
    }
}
