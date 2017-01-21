using FluentNHibernate.Mapping;
using System;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapTipoParentesco  : ClassMap<TipoParentesco >
    {
        public MapTipoParentesco()
        {
            //Table
            Table("TipoParentesco ");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.Parente).Column("Parente").Not.Nullable();
            Map(x => x.GrauParentesco).Column("GrauParentesco").Not.Nullable();

        }
    }
}
