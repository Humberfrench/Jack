using FluentNHibernate.Mapping;
using System;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapFamiliaBlackList : ClassMap<FamiliaBlackList>
    {
        public MapFamiliaBlackList()
        {
            //Table
            Table("FamiliaBlackList");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Ano).Column("Ano").Not.Nullable();

            //References
            References(x => x.Familia).Column("Familia").Not.Nullable();




        }
    }
}
